using System;

using Android.App;
using Android.Content.PM;

using MvvmCross.Platforms.Android.Views;
using MobileTemplateCSharp.Core;

namespace MobileTemplateCSharp.Droid.Views {
    [Activity(
        Label = nameof(SplashScreenView)
        , MainLauncher = true
        //, Icon = "@drawable/icon"
        , Theme = "@style/SplashTheme"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenView : MvxSplashScreenActivity {
        public SplashScreenView() : base() { }
    }
}
