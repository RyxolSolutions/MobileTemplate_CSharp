using System;
using System.Linq;

using Foundation;
using UIKit;
using CoreGraphics;

using MvvmCross.Commands;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

using MobileTemplateCSharp.Core.ViewModels.Base;

using PopupMessage = System.ValueTuple<string, string, string, string, System.Action, System.Action>;
using MobileTemplateCSharp.iOS.Managers;

namespace MobileTemplateCSharp.iOS.Views.Base {
    public abstract class BaseView<TViewModel> : MvxViewController<TViewModel> where TViewModel : class, IBaseViewModel {
        public BaseView(string nibName, NSBundle bundle) : base(nibName, bundle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            var type = this.GetType();
            var attrs = type.CustomAttributes;

            //bad descision
            var tabAttr = from attrinbute in attrs where attrinbute.AttributeType == typeof(MvxTabPresentationAttribute) select attrinbute;
            if (tabAttr.Count() == 0)
                this.Title = ViewModel.Title;

            InitLoadingBar();
            InitPopups();
        }

        #region Popups

        private void InitPopups() {
            ViewModel.ShowPopupCommand = new MvxCommand<PopupMessage>(ShowPopup);
        }

        private void ShowPopup(PopupMessage parameters) {
            var (title, message, positiveButtonText, negativeButtonText, positiveClick, negativeClick) = parameters;
            InvokeOnMainThread(() => {
                UIAlertController alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
                if (!string.IsNullOrEmpty(positiveButtonText))
                    alert.AddAction(UIAlertAction.Create(positiveButtonText, UIAlertActionStyle.Default, action => positiveClick()));
                if (!string.IsNullOrEmpty(negativeButtonText))
                    alert.AddAction(UIAlertAction.Create(negativeButtonText, UIAlertActionStyle.Cancel, action => negativeClick()));
                PresentViewController(alert, true, null);
            });
        }

        #endregion

        #region LoadingBar

        private UIActivityIndicatorView LoadingBar;
        private UIView LoadingBackgroundView;

        private void InitLoadingBar() {
            ViewModel.HideLoadingBarCommand = new MvxCommand(HideLoadingBar);
            ViewModel.ShowLoadingBarCommand = new MvxCommand(ShowLoadingBar);
        }

        private void HideLoadingBar() {
            InvokeOnMainThread(() => {
                LoadingBar.StopAnimating();
                UIView.Animate(0.1, () => LoadingBackgroundView.Alpha = 0.0f);
                LoadingBackgroundView.RemoveFromSuperview();
                LoadingBar.RemoveFromSuperview();
                LoadingBar.Dispose();
                LoadingBackgroundView.Dispose();
            });
        }

        private void ShowLoadingBar() {
            InvokeOnMainThread(() => {
                LoadingBar = new UIActivityIndicatorView(new CGRect(0, 0, 100, 100)) {
                    Center = View.Center,
                    ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.White
                };

                LoadingBackgroundView = new UIView {
                    Center = View.Center
                };
                LoadingBackgroundView.Frame = new CGRect(new CGPoint(View.Frame.Location), new CGSize(View.Frame.Size));
                LoadingBackgroundView.BackgroundColor = ColorManager.progressbar_background;
                LoadingBackgroundView.Alpha = 0;


                View.AddSubview(LoadingBackgroundView);
                LoadingBar.StartAnimating();
                View.AddSubview(LoadingBar);
                UIView.Animate(0.3, () => LoadingBackgroundView.Alpha = 0.7f);
            });
        }

        #endregion
    }
}
