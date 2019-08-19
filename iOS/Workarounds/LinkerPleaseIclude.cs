using System;
using MvvmCross;
using UIKit;

namespace MobileTemplateCSharp.iOS.Workarounds {
    [Preserve(AllMembers = true)]
    public class LinkerPleaseInclude {
        public void Include(UITextField textField) {
            textField.Text = textField.Text + "";
            textField.EditingChanged += (sender, args) => { textField.Text = ""; };
        }

        public void Include(UIButton uiButton) {
            uiButton.TouchUpInside += (s, e) => uiButton.SetTitle(uiButton.Title(UIControlState.Normal), UIControlState.Normal);
        }
    }
}