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
	[Register ("ContainingFragmentView")]
	partial class ContainingFragmentView
	{
		[Outlet]
		UIKit.UIView Container { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Container != null) {
				Container.Dispose ();
				Container = null;
			}
		}
	}
}
