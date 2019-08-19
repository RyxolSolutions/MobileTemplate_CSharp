using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;

using MvvmCross.Commands;
using MvvmCross.Droid.Support.V4;
using MvvmCross.ViewModels;

using MobileTemplateCSharp.Core.ViewModels.Base;
using PopupMessage = System.ValueTuple<string, string, string, string, System.Action, System.Action>;
using MobileTemplateCSharp.Droid.Extensions;
using MobileTemplateCSharp.Droid.Views.Base;

namespace MobileTemplateCSharp.Droid.Views.Fragments.Base {
    /// <summary>
    /// Base Fragment with ViewModel implementation. Creates generic ViewModel in constructor.
    /// </summary>
    /// <typeparam name="TViewModel">Type of ViewModel for Fragment</typeparam>
    public abstract class BaseFragmentView<TViewModel> : MvxFragment<TViewModel> where TViewModel : class, IBaseViewModel {

        public BaseFragmentView(IntPtr a, JniHandleOwnership b) : base(a, b) {
            Instantiate();
        }

        public BaseFragmentView() {
            Instantiate();
        }

        public void Instantiate() {
            MvxViewModelRequest request = (MvxViewModelRequest)Activator.CreateInstance(typeof(MvxViewModelRequest<>).MakeGenericType(typeof(TViewModel)));
            this.LoadViewModelFrom(request);

            ViewModel.ShowPopupCommand = new MvxCommand<PopupMessage>(this.ShowPopup);
            ViewModel.HideLoadingBarCommand = new MvxCommand(this.HideLoadingBar);
            ViewModel.ShowLoadingBarCommand = new MvxCommand(this.ShowLoadingBar);
        }

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            RootLayout = container ?? (ViewGroup)Activity.Window.DecorView.RootView;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected ViewGroup RootLayout { get; set; }
    }
}
