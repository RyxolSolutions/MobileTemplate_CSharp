using System;
using Android.Support.V7.App;
using Android.Views;
using MobileTemplateCSharp.Core.ViewModels.Base;
using MobileTemplateCSharp.Droid.Views.Base;
using MobileTemplateCSharp.Droid.Views.Fragments;
using MobileTemplateCSharp.Droid.Views.Fragments.Base;

namespace MobileTemplateCSharp.Droid.Extensions.Base {
    public static class BaseListExtensions {

        #region dynamic

        public static void ShowEmplyList_abstract(AppCompatActivity activity, IBaseListView baseListView) {
            activity.RunOnUiThread(() => {
                baseListView.ListView.Visibility = ViewStates.Gone;
                if (baseListView.EmptyListFragmentView == null) {
                    baseListView.EmptyListFragmentView = new EmptyListFragmentView();
                    activity.SupportFragmentManager
                        .BeginTransaction()
                        .Add(baseListView.ListViewContainer.Id, baseListView.EmptyListFragmentView)
                        .Commit();

                }
            });
        }

        public static void HideEmplyList_abstract(AppCompatActivity activity, IBaseListView baseListView) {
            activity.RunOnUiThread(() => {
                baseListView.ListView.Visibility = ViewStates.Visible;
                if (baseListView.EmptyListFragmentView != null) {
                    activity.SupportFragmentManager
                        .BeginTransaction()
                        .Remove(baseListView.EmptyListFragmentView)
                        .Commit();
                    baseListView.EmptyListFragmentView = null;
                }
            });
        }

        public static void RefreshList_abstract(IBaseListView baseListView) {
            baseListView.ListView.GetAdapter().NotifyDataSetChanged();
        }

        #endregion

        #region BaseListView

        public static void RefreshList<TViewModel>(this BaseListView<TViewModel> self) where TViewModel : class, IBaseListViewModel {
            RefreshList_abstract(self);
        }

        public static void HideEmplyList<TViewModel>(this BaseListView<TViewModel> self) where TViewModel : class, IBaseListViewModel {
            HideEmplyList_abstract(self, self);
        }

        public static void ShowEmplyList<TViewModel>(this BaseListView<TViewModel> self) where TViewModel : class, IBaseListViewModel {
            ShowEmplyList_abstract(self, self);
        }

        #endregion

        #region BaseListFragmentView

        public static void RefreshList<TViewModel>(this BaseListFragmentView<TViewModel> self) where TViewModel : class, IBaseListViewModel {
            RefreshList_abstract(self);
        }

        public static void HideEmplyList<TViewModel>(this BaseListFragmentView<TViewModel> self) where TViewModel : class, IBaseListViewModel {
            HideEmplyList_abstract((AppCompatActivity)self.Activity, self);
        }

        public static void ShowEmplyList<TViewModel>(this BaseListFragmentView<TViewModel> self) where TViewModel : class, IBaseListViewModel {
            ShowEmplyList_abstract((AppCompatActivity)self.Activity, self);
        }

        #endregion
    }
}
