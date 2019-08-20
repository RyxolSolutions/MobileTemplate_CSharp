using System;
using Foundation;
using MobileTemplateCSharp.Core.ViewModels.Fragments;
using MobileTemplateCSharp.iOS.Views.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace MobileTemplateCSharp.iOS.Views.Fragments {
    public partial class ListFragmentView : BaseListView<ListFragmentViewModel> {
        public ListFragmentView() : base(nameof(ListFragmentView), null) {
        }

        private MvxTableViewSource Source;

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            Source = new MvxStandardTableViewSource(TableView, UITableViewCellStyle.Subtitle, new NSString("SimpleBindableTableViewCell"), "TitleText Title", UITableViewCellAccessory.None);
            TableView.Source = Source;

            var set = this.CreateBindingSet<ListFragmentView, ListFragmentViewModel>();
            set.Bind(Source).To(vm => vm.Items);
            set.Bind(Source).For(v => v.SelectionChangedCommand).To(vm => vm.RemoveItemCommand);
            set.Bind(DownButton).To(vm => vm.ReloadListCommand);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

