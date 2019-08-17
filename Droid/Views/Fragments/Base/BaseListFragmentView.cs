using System;

using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

using MvvmCross.Commands;

using MobileTemplateCSharp.Core.ViewModels.Base;

namespace MobileTemplateCSharp.Droid.Views.Fragments.Base {
    public abstract class BaseListFragmentView<TViewModel> : BaseFragmentView<TViewModel> where TViewModel : class, IBaseListViewModel {
        #region View

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            Container = container;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnStart() {
            base.OnStart();

            ViewModel.ShowEmplyListCommand = new MvxCommand(ShowEmplyList);
            ViewModel.HideEmplyListCommand = new MvxCommand(HideEmplyList);
            ViewModel.RefreshListCommand = new MvxCommand(RefreshList);
        }

        #endregion

        #region Commands

        protected virtual void ShowEmplyList() {
            Activity.RunOnUiThread(() => {
            });
        }

        protected virtual void HideEmplyList() {
            Activity.RunOnUiThread(() => {
            });
        }

        protected virtual void RefreshList() {
            RecyclerView.GetAdapter().NotifyDataSetChanged();
        }

        #endregion

        #region Properties
        protected abstract RecyclerView RecyclerView { get; }
        protected ViewGroup Container { get; set; }
        #endregion
    }
}
