
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using MobileTemplateCSharp.Core.ViewModels.Fragments;
using MobileTemplateCSharp.Droid.Views.Fragments.Base;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace MobileTemplateCSharp.Droid.Views.Fragments {
    public class ListFragmentView : BaseListFragmentView<ListFragmentViewModel> {

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = this.BindingInflate(Resource.Layout.ListFragmentView, null);
            return view;
        }
    }
}
