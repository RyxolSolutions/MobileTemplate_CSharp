using System;

using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;

using MobileTemplateCSharp.Core;
using System.Collections.Generic;
using System.Reflection;
using MvvmCross.Droid.Support.V7.RecyclerView;

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

        public override IEnumerable<Assembly> GetViewAssemblies() =>
            new List<Assembly>(base.GetViewAssemblies()) {
                typeof(MvxRecyclerView).Assembly
            };
    }
}
