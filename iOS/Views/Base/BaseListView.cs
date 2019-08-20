using System;

using CoreGraphics;
using Foundation;
using UIKit;

using MvvmCross.Commands;

using MobileTemplateCSharp.Core.ViewModels.Base;
using System.Linq;
using System.Reflection;

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

        protected UITableView _tableView;
        protected virtual UITableView GetTableView {
            get {
                _tableView = _tableView ?? getTableView_Reflection();
                return _tableView;
            }
        }

        protected virtual UITableView getTableView_Reflection() =>
            this.GetType()
                .GetProperties(BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy | BindingFlags.Instance)
                .Where(prop => Attribute.IsDefined(prop, typeof(OutletAttribute)))
                .Where(prop => prop.PropertyType == typeof(UITableView))
                .FirstOrDefault()
                ?.GetValue(this)
                as UITableView;

        private UILabel EmpltyListLabel;

        private void HideEmplyList() {
            InvokeOnMainThread(() => {
                GetTableView.Hidden = false;
                if (EmpltyListLabel != null) {
                    EmpltyListLabel.RemoveFromSuperview();
                    EmpltyListLabel.Dispose();
                    EmpltyListLabel = null;
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
