using System;

using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;

using MvvmCross.Commands;

using MobileTemplateCSharp.Core.ViewModels.Base;
using Android.Support.V4.App;
using MobileTemplateCSharp.Droid.Views.Base;
using Android.Runtime;
using MobileTemplateCSharp.Droid.Extensions.Base;

namespace MobileTemplateCSharp.Droid.Views.Fragments.Base {
    public abstract class BaseListFragmentView<TViewModel> : BaseFragmentView<TViewModel>, IBaseListView where TViewModel : class, IBaseListViewModel {
        #region View

        public BaseListFragmentView(IntPtr a, JniHandleOwnership b) : base(a, b) {
            InstantiateCommands();
        }

        public BaseListFragmentView() {
            InstantiateCommands();
        }

        private void InstantiateCommands() {
            ViewModel.ShowEmplyListCommand = new MvxCommand(this.ShowEmplyList);
            ViewModel.HideEmplyListCommand = new MvxCommand(this.HideEmplyList);
            ViewModel.RefreshListCommand = new MvxCommand(this.RefreshList);
        }

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnStart() {
            base.OnStart();
            this.FindRecyclerView(RootLayout);
        }

        #endregion

        #region IBaseListView
        public ViewGroup ListViewContainer { get; set; }
        public Fragment EmptyListFragmentView { get; set; }
        public RecyclerView ListView { get; set; }
        #endregion
    }
}
