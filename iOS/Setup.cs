using System;

using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Plugin;
using MvvmCross.ViewModels;

using MobileTemplateCSharp.Core;

namespace MobileTemplateCSharp.iOS {
    public class Setup : MvxIosSetup<App> {
        public Setup() {
        }

        protected override IMvxApplication CreateApp() {
            return new Core.App();
        }

        protected override void InitializeFirstChance() {
            base.InitializeFirstChance();
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager) {
            base.LoadPlugins(pluginManager);
        }

        protected override void InitializePlatformServices() {
            base.InitializePlatformServices();
        }

        protected override void InitializeLastChance() {
            base.InitializeLastChance();
        }
    }
}
