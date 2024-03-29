﻿using System;
using UIKit;

namespace MobileTemplateCSharp.iOS.Managers {
    public static class ColorManager {
        public static UIColor bgr_white = FromHexString("#FFFFFF");
        public static UIColor bgr_black = FromHexString("#000000");
        public static UIColor content_gray = FromHexString("#A5A09D");
        public static UIColor content_green = FromHexString("#2BF60E");
        public static UIColor content_orange = FromHexString("#E96015");
        public static UIColor content_blue = FromHexString("#517CA8");
        public static UIColor text_gray = FromHexString("#5A5957");
        public static UIColor progressbar_background = FromHexString("#1976D2");

        #region Converters

        public static UIColor FromHexString(string hexValue) {
            var colorString = hexValue.Replace("#", "");
            float red, green, blue;

            switch (colorString.Length) {
                case 3: // #RGB
                    {
                        red = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(0, 1)), 16) / 255f;
                        green = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(1, 1)), 16) / 255f;
                        blue = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(2, 1)), 16) / 255f;
                        return UIColor.FromRGB(red, green, blue);
                    }
                case 6: // #RRGGBB
                    {
                        red = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                        green = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                        blue = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                        return UIColor.FromRGB(red, green, blue);
                    }
                case 8: // #AARRGGBB
                    {
                        var alpha = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                        red = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                        green = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                        blue = Convert.ToInt32(colorString.Substring(6, 2), 16) / 255f;
                        return UIColor.FromRGBA(red, green, blue, alpha);
                    }
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid color value {0} is invalid. It should be a hex value of the form #RBG, #RRGGBB, or #AARRGGBB", hexValue));

            }
        }

        #endregion
    }
}
