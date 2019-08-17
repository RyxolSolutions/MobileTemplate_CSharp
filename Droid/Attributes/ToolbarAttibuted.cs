using System;
namespace MobileTemplateCSharp.Droid.Attributes {
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class ToolbarAttribute : Attribute {

        public int ToolbarResource { get; private set; } 
        public bool NeedBackButton { get; private set; } 

        public ToolbarAttribute(
            int ToolbarResource = Resource.Id.toolbar,
            bool NeedBackButton = false
        ) {
            this.ToolbarResource = ToolbarResource;
            this.NeedBackButton = NeedBackButton;
        }
    }
}
