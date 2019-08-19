using System;

using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

using MvvmCross.Commands;

using MobileTemplateCSharp.Core.ViewModels.Base;
using MobileTemplateCSharp.Droid.Views.Fragments;
using Android.Support.V4.App;
using Android.Content;

namespace MobileTemplateCSharp.Droid.Views.Base {
    public abstract class BaseListView<TViewModel> : BaseView<TViewModel> where TViewModel : class, IBaseListViewModel {

        #region View

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);


            ViewModel.ShowEmplyListCommand = new MvxCommand(ShowEmplyList);
            ViewModel.HideEmplyListCommand = new MvxCommand(HideEmplyList);
            ViewModel.RefreshListCommand = new MvxCommand(RefreshList);
        }

        protected override void OnStart() {
            base.OnStart();
            FindRecyclerView(RootLayout);
        }

        protected override void OnResume() {
            base.OnResume();
        }

        private void FindRecyclerView(ViewGroup viewGroup) {
            for (int i = 0; i < viewGroup.ChildCount; i++) {
                View view = viewGroup.GetChildAt(i);
                if (view is ViewGroup group)
                    FindRecyclerView(group);
                if (view is RecyclerView recyclerView) {
                    ListView = recyclerView;
                    ListView.Id = Resource.Id.recycler_view;
                    Container = viewGroup;
                    Container.Id = Resource.Id.recycler_view_container;
                    return;
                }
            }
        }

        #endregion

        #region Empty List
        protected Fragment emptyListFragmentView { get; set; }
        protected ViewGroup Container { get; set; }

        protected virtual Fragment EmptyListFragmentView { get => emptyListFragmentView; set => emptyListFragmentView = value; }

        protected virtual void ShowEmplyList() {
            RunOnUiThread(() => {
                ListView.Visibility = ViewStates.Gone;
                if (EmptyListFragmentView == null) {
                    EmptyListFragmentView = new EmptyListFragmentView();
                    base.SupportFragmentManager
                        .BeginTransaction()
                        .Add(Container.Id, EmptyListFragmentView)
                        .Commit();
                }
            });
        }

        protected virtual void HideEmplyList() {
            RunOnUiThread(() => {
                ListView.Visibility = ViewStates.Visible;
                if (EmptyListFragmentView != null) {
                    SupportFragmentManager
                        .BeginTransaction()
                        .Remove(EmptyListFragmentView)
                        .Commit();
                    EmptyListFragmentView = null;
                }
            });
        }

        protected virtual void RefreshList() {
            ListView.GetAdapter().NotifyDataSetChanged();
        }

        #endregion

        #region Properties
        protected virtual RecyclerView ListView { get; set; }
        #endregion
    }
}