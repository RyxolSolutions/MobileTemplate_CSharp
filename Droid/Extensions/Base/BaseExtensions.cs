using System;
using System.Reflection;
using Android.App;
using Android.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using MobileTemplateCSharp.Core.ViewModels.Base;
using MobileTemplateCSharp.Droid.Views.Base;
using MobileTemplateCSharp.Droid.Views.Fragments.Base;
using MvvmCross.Droid.Support.V7.AppCompat;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Fragment = Android.Support.V4.App.Fragment;
using PopupMessage = System.ValueTuple<string, string, string, string, System.Action, System.Action>;


namespace MobileTemplateCSharp.Droid.Extensions {
    public static class BaseExtensions {

        #region Popup

        public static void ShowPopup(this AppCompatActivity self, PopupMessage parameters) {
            ShowPopup(self, self, parameters);
        }

        public static void ShowPopup(this Fragment self, PopupMessage parameters) {
            ShowPopup(self.Context, self.Activity, parameters);
        }

        public static void ShowPopup(Context context, Activity activity, PopupMessage parameters) {
            var (title, message, positiveButtonText, negativeButtonText, positiveClick, negativeClick) = parameters;
            using (AlertDialog.Builder builder = new AlertDialog.Builder(context)) {
                builder.SetTitle(title);
                builder.SetMessage(message);
                if (!string.IsNullOrEmpty(positiveButtonText))
                    builder.SetPositiveButton(positiveButtonText, (senderAlert, args) => positiveClick());
                if (!string.IsNullOrEmpty(negativeButtonText))
                    builder.SetNegativeButton(negativeButtonText, (senderAlert, args) => negativeClick());
                activity.RunOnUiThread(() => {
                    Dialog dialog = builder.Create();
                    dialog.Show();
                });
            }
        }

        #endregion

        #region Loading Bar for Activity

        public static void ShowLoadingBar<TViewModel>(this BaseView<TViewModel> self) where TViewModel : class, IBaseViewModel {
            if (self.RootLayout != null && self.LoadingBarLayout == null) {
                ViewGroup.LayoutParams param = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                self.LoadingBarLayout = new RelativeLayout(self) {
                    LayoutParameters = param,
                    Alpha = self.AlphaVisible
                };
#pragma warning disable CS0618 // Type or member is obsolete
                self.LoadingBarLayout.SetBackgroundColor(self.Resources.GetColor(Resource.Color.progressbar_background));
#pragma warning restore CS0618 // Type or member is obsolete
                self.ProgressBar = new ProgressBar(self);
                self.LoadingBarLayout.SetGravity(GravityFlags.Center);


                self.RunOnUiThread(() => {
                    self.LoadingBarLayout.AddView(self.ProgressBar);
                    self.RootLayout.AddView(self.LoadingBarLayout);
                });
            }
            self.RunOnUiThread(() => {
                AlphaAnimation showAnimation = new AlphaAnimation(self.AlphaHidden, self.AlphaVisible) {
                    Duration = self.AnimationLoadingBarApperaringDuration,
                    FillAfter = true
                };
                self.LoadingBarLayout.StartAnimation(showAnimation);
            });
        }

        public static void HideLoadingBar<TViewModel>(this BaseView<TViewModel> self) where TViewModel : class, IBaseViewModel {
            if (self.LoadingBarLayout != null) {
                self.LoadingBarLayout.BringToFront();
                self.RunOnUiThread(() => {
                    AlphaAnimation hideAnimation = new AlphaAnimation(self.AlphaVisible, self.AlphaHidden) {
                        Duration = self.AnimationLoadingBarApperaringDuration,
                        FillAfter = true
                    };
                    self.LoadingBarLayout.StartAnimation(hideAnimation);
                });
            }
        }
        #endregion
    }


    /// Extensions are splited for convinience of work with Reflection
    public static class BaseFragmentExtensions {
        #region Loading Bar for Fragment

        public static void ShowLoadingBar<TViewModel>(this BaseFragmentView<TViewModel> self) where TViewModel : class, IBaseViewModel =>
            typeof(BaseExtensions).GetMethod("ShowLoadingBar", BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod((self.Activity as MvxAppCompatActivity).ViewModel.GetType())
                .Invoke(null, new[] { self.Activity });

        public static void HideLoadingBar<TViewModel>(this BaseFragmentView<TViewModel> self) where TViewModel : class, IBaseViewModel =>
            typeof(BaseExtensions).GetMethod("HideLoadingBar", BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod((self.Activity as MvxAppCompatActivity).ViewModel.GetType())
                .Invoke(null, new[] { self.Activity });

        #endregion
    }
}
