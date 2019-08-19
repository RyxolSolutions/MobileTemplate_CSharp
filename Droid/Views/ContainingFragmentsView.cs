
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileTemplateCSharp.Core.ViewModels;
using MobileTemplateCSharp.Droid.Attributes;
using MobileTemplateCSharp.Droid.Views.Base;

namespace MobileTemplateCSharp.Droid.Views {
    [Toolbar(NeedBackButton: true)]
    [Activity(Label = "ContainingFragmentsView")]
    public class ContainingFragmentsView : BaseView<ContainingFragmentsViewModel> {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ContainingFragmentsView);
        }
    }
}
