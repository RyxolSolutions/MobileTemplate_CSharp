using System;

using CoreGraphics;
using Foundation;
using UIKit;

using MvvmCross.Commands;

using MobileTemplateCSharp.Core.ViewModels.Base;

namespace MobileTemplateCSharp.iOS.Views.Base {
    public abstract class BaseListView<TViewModel> : BaseView<TViewModel> where TViewModel : class, IBaseListViewModel {
        public BaseListView(string nibName, NSBundle bundle) : base(nibName, bundle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            ViewModel.HideEmplyListCommand = new MvxCommand(HideEmplyList);
            ViewModel.ShowEmplyListCommand = new MvxCommand(ShowEmplyList);
            ViewModel.RefreshListCommand = new MvxCommand(RefreshList);
            // Perform any additional setup after loading the view, typically from a nib.
        }


        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
        }

        #region List

        protected abstract UITableView GetTableView { get; }

        //private UIImageView EmptyListImageView;
        private UILabel EmpltyListLabel;

        private void HideEmplyList() {
            InvokeOnMainThread(() => {
                GetTableView.Hidden = false;
                if (EmpltyListLabel != null) {
                    EmpltyListLabel.RemoveFromSuperview();
                    EmpltyListLabel.Dispose();
                }
            });
        }

        private void ShowEmplyList() {
            InvokeOnMainThread(() => {
                if (EmpltyListLabel == null) {
                    EmpltyListLabel = new UILabel(
                        new CGRect(
                            GetTableView.Center.X - GetTableView.Frame.Width / 2,
                            GetTableView.Center.Y - 30,
                            GetTableView.Frame.Width,
                            30)
                        ) {
                        Text = ViewModel.EmptyListTitle,
                        TextAlignment = UITextAlignment.Center
                    };
                    View.AddSubview(EmpltyListLabel);
                }
                GetTableView.Hidden = true;
            });
        }

        private void RefreshList() {
            InvokeOnMainThread(() => {
                GetTableView.ReloadData();
            });
        }

        #endregion
    }
}
