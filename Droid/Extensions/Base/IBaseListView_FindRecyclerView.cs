using System;
using Android.Support.V7.Widget;
using Android.Views;
using MobileTemplateCSharp.Droid.Views.Base;

namespace MobileTemplateCSharp.Droid.Extensions.Base {
    public static class IBaseListView_FindRecyclerView {
        public static void FindRecyclerView(this IBaseListView self, ViewGroup viewGroup) {
            for (int i = 0; i < viewGroup.ChildCount; i++) {
                View view = viewGroup.GetChildAt(i);
                if (view is ViewGroup group)
                    self.FindRecyclerView(group);
                if (view is RecyclerView recyclerView) {
                    self.ListView = recyclerView;
                    self.ListView.Id = Resource.Id.recycler_view;
                    self.ListViewContainer = viewGroup;
                    self.ListViewContainer.Id = Resource.Id.recycler_view_container;
                    return;
                }
            }
        }
    }
}
