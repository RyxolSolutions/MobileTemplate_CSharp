// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MobileTemplateCSharp.iOS.Views
{
	[Register ("ListView")]
	partial class ListView
	{
		[Outlet]
		UIKit.UIButton DownButton { get; set; }

		[Outlet]
        UIKit.UITableView TableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}

			if (DownButton != null) {
				DownButton.Dispose ();
				DownButton = null;
			}
		}
	}
}
