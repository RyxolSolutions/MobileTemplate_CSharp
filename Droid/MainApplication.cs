﻿using System;

using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;

using MvvmCross.Platforms.Android.Views;

using MobileTemplateCSharp.Core;

using Plugin.CurrentActivity;

namespace MobileTemplateCSharp.Droid {
    //You can specify additional application information in this attribute
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, App>, Application.IActivityLifecycleCallbacks {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer) { }

        public override void OnCreate() {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate() {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState) {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity) {

        }

        public void OnActivityPaused(Activity activity) {

        }

        public void OnActivityResumed(Activity activity) {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState) {

        }

        public void OnActivityStarted(Activity activity) {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity) {

        }
    }
}
