using System;

using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

using MvvmCross.Commands;

using MobileTemplateCSharp.Core.ViewModels.Base;

namespace MobileTemplateCSharp.Droid.Views.Base {
    public abstract class BaseListView<TViewModel> : BaseView<TViewModel> where TViewModel : class, IBaseListViewModel {

        #region View

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
        }

        protected override void OnStart() {
            base.OnStart();

            ViewModel.ShowEmplyListCommand = new MvxCommand(ShowEmplyList);
            ViewModel.HideEmplyListCommand = new MvxCommand(HideEmplyList);
            ViewModel.RefreshListCommand = new MvxCommand(RefreshList);
        }

        #endregion

        #region Commands

        protected virtual void ShowEmplyList() {
            RunOnUiThread(() => {
            });
        }

        protected virtual void HideEmplyList() {
            RunOnUiThread(() => {
            });
        }

        protected virtual void RefreshList() {
            RecyclerView.GetAdapter().NotifyDataSetChanged();
        }

        #endregion

        #region Properties
        protected abstract RecyclerView RecyclerView { get; }
        #endregion
    }
}
