using System;

using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

using MvvmCross.Commands;

using MobileTemplateCSharp.Core.ViewModels.Base;
using MobileTemplateCSharp.Droid.Views.Fragments;
using Android.Support.V4.App;
using Android.Content;
using MobileTemplateCSharp.Droid.Extensions.Base;

namespace MobileTemplateCSharp.Droid.Views.Base {
    public abstract class BaseListView<TViewModel> : BaseView<TViewModel>, IBaseListView where TViewModel : class, IBaseListViewModel {

        #region View

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            InstantiateCommands();
        }

        private void InstantiateCommands() {
            ViewModel.ShowEmplyListCommand = new MvxCommand(this.ShowEmplyList);
            ViewModel.HideEmplyListCommand = new MvxCommand(this.HideEmplyList);
            ViewModel.RefreshListCommand = new MvxCommand(this.RefreshList);
        }

        protected override void OnStart() {
            base.OnStart();
            this.FindRecyclerView(RootLayout);
        }

        protected override void OnResume() {
            base.OnResume();
        }

        #endregion

        #region IBaseListView
        public ViewGroup ListViewContainer { get; set; }
        public Fragment EmptyListFragmentView { get; set; }
        public RecyclerView ListView { get; set; }
        #endregion
    }
}