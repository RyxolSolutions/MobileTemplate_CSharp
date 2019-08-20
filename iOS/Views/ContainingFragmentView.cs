using System;
using MobileTemplateCSharp.Core.ViewModels;
using MobileTemplateCSharp.Core.ViewModels.Fragments;
using MobileTemplateCSharp.iOS.Extensions;
using MobileTemplateCSharp.iOS.Views.Base;
using MobileTemplateCSharp.iOS.Views.Fragments;
using UIKit;

namespace MobileTemplateCSharp.iOS.Views {
    public partial class ContainingFragmentView : BaseView<ContainingFragmentsViewModel> {
        public ContainingFragmentView() : base("ContainingFragmentView", null) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            this.AddFragmentViewModel<ListFragmentViewModel>(Container);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

