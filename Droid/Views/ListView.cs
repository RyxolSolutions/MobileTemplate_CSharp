
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MobileTemplateCSharp.Core.Models.Cells;
using MobileTemplateCSharp.Core.ViewModels;
using MobileTemplateCSharp.Droid.Attributes;
using MobileTemplateCSharp.Droid.Views.Base;

namespace MobileTemplateCSharp.Droid.Views {
    [Toolbar(NeedBackButton: true)]
    [Activity(Label = "EmptyListView")]
    public class ListView : BaseListView<ListViewModel> {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ListView);
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.list_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            int id = item.ItemId;
            switch (id) {
                case Resource.Id.list_remove:
                    ViewModel.RemoveItem(ViewModel.Items.FirstOrDefault());
                    break;
                case Resource.Id.list_add:
                    ViewModel.AddItem();
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}
