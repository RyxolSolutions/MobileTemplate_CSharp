using System;

using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;

using MobileTemplateCSharp.Core;

namespace MobileTemplateCSharp.Droid {
    public class Setup : MvxAndroidSetup<App> {

        public Setup() {
        }

        protected override IMvxApplication CreateApp() {
            return new Core.App();
        }

        protected override void InitializeFirstChance() {
            base.InitializeFirstChance();
        }

        protected override void InitializeLastChance() {
            base.InitializeLastChance();
        }

        protected override void InitializePlatformServices() {
            base.InitializePlatformServices();

        }
    }
}
