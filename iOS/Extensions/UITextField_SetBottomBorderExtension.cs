using System;

using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace MobileTemplateCSharp.iOS.Extensions {
    public static class UITextField_SetBottomBorderExtension {
        public static void SetBottomBorder(this UITextField self, UIColor color) {
            //self.Layer.ShadowColor = color.CGColor;
            //self.Layer.ShadowOffset = new CGSize(0, 1);
            //self.Layer.ShadowOpacity = 1;
            //self.Layer.ShadowRadius = 0;
            //self.BorderStyle = UITextBorderStyle.None;
            //self.BackgroundColor = UIColor.White;

            self.Layer.CornerRadius = 0;
            self.Layer.MasksToBounds = true;
            self.BorderStyle = UITextBorderStyle.None;

            var border = new CALayer();
            var borderWidth = 1f;
            border.BorderColor = color.CGColor;

            self.SetNeedsLayout();
            self.LayoutIfNeeded();
            border.Frame = new CGRect(0, self.Frame.Size.Height - borderWidth, self.Frame.Size.Width, self.Frame.Size.Height);

            border.BorderWidth = borderWidth;
            self.Layer.AddSublayer(border);
            self.Layer.MasksToBounds = true;
        }

        public static void SetBottomBorder(this UITextView self, UIColor color) {
            self.Layer.CornerRadius = 0;
            self.Layer.MasksToBounds = true;

            var border = new CALayer();
            var borderWidth = 1f;
            border.BorderColor = color.CGColor;

            self.SetNeedsLayout();
            self.LayoutIfNeeded();
            border.Frame = new CGRect(0, self.Frame.Size.Height - borderWidth, self.Frame.Size.Width, borderWidth);

            border.BorderWidth = borderWidth;
            self.Layer.AddSublayer(border);
        }
    }
}
