using System;
using MobileTemplateCSharp.Core.ViewModels;
using MobileTemplateCSharp.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using UIKit;

namespace MobileTemplateCSharp.iOS.Views {
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class HomeView : BaseView<HomeViewModel> {
        public HomeView() : base(nameof(HomeView), null) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Bind(RoundButton).For("Title").To(vm => vm.RoundButtonText);
            set.Bind(RoundButton).To(vm => vm.RoundButtonClickCommand);
            set.Apply();
        }

        public override void ViewDidAppear(bool animated) {
            base.ViewDidAppear(animated);
            RoundButton.Layer.CornerRadius = RoundButton.Bounds.Width / 2;
        }

        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
        }
    }
}

