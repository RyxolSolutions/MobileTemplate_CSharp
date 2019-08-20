using System;
using UIKit;
using Foundation;

using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

using MobileTemplateCSharp.Core.ViewModels;
using MobileTemplateCSharp.iOS.Views.Base;

namespace MobileTemplateCSharp.iOS.Views {
    [MvxChildPresentation]
    public partial class ListView : BaseListView<ListViewModel> {
        public ListView() : base(nameof(ListView), null) {
        }

        private MvxTableViewSource Source;

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            Source = new MvxStandardTableViewSource(TableView, UITableViewCellStyle.Subtitle, new NSString("SimpleBindableTableViewCell"), "TitleText Title", UITableViewCellAccessory.None);
            TableView.Source = Source;

            var set = this.CreateBindingSet<ListView, ListViewModel>();
            set.Bind(Source).To(vm => vm.Items);
            set.Bind(Source).For(v => v.SelectionChangedCommand).To(vm => vm.RemoveItemCommand);
            set.Bind(DownButton).To(vm => vm.NextPageCommand);
            set.Bind(DownButton).For("Title").To(vm => vm.ButtonTitle);
            set.Apply();

            TableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

