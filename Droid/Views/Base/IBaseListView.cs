using System;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace MobileTemplateCSharp.Droid.Views.Base {
    public interface IBaseListView {
        ViewGroup ListViewContainer { get; set; }
        Fragment EmptyListFragmentView { get; set; }
        RecyclerView ListView { get; set; }
    }
}
