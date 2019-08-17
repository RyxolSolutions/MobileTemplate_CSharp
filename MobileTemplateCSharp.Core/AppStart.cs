using System;
using System.Linq;
using System.Threading.Tasks;


using MvvmCross.Navigation;
using MvvmCross.ViewModels;

using MobileTemplateCSharp.Core.ViewModels;
using MobileTemplateCSharp.Core.Database.Interfaces;
using MobileTemplateCSharp.Core.Models.Database;
using MobileTemplateCSharp.Core.Rest.Interfaces;
//using MobileTemplateCSharp.Core.Services.Interfaces;
using MobileTemplateCSharp.Core.Models.Rest;

namespace MobileTemplateCSharp.Core {
    /// <summary>
    /// Class for starting app. Here application chose first view.
    /// </summary>
    public class AppStart : MvxAppStart {
        public AppStart(
            IMvxApplication app,
            IMvxNavigationService mvxNavigationService
        ) : base(app, mvxNavigationService) {

        }

        protected override async Task NavigateToFirstViewModel(object hint = null) {
            await NavigationService.Navigate<HomeViewModel>();
        }
    }
}
