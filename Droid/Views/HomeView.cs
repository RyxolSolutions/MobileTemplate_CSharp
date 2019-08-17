using System;

using Android;
using Android.Content.PM;
using Android.Runtime;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Content;
using Android.Support.V4.View;

using MvvmCross.Platforms.Android.Presenters.Attributes;

using MobileTemplateCSharp.Core.ViewModels;
using MobileTemplateCSharp.Droid.Views.Base;
using Android.Views;
using MobileTemplateCSharp.Droid.Attributes;

namespace MobileTemplateCSharp.Droid.Views {
    [Toolbar]
    [MvxActivityPresentation]
    [Activity(Label = "HomeView")]
    public class HomeView : BaseView<HomeViewModel> {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
        }
    }
}
