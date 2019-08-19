using System;
using System.Threading;
using System.Threading.Tasks;
using MobileTemplateCSharp.Core.Localization;
using MobileTemplateCSharp.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MobileTemplateCSharp.Core.ViewModels {
    public class HomeViewModel : BaseViewModel {
        public HomeViewModel(
            IMvxNavigationService mvxNavigationService
        ) {
            this.mvxNavigationService = mvxNavigationService;

            RoundButtonClickCommand = new MvxAsyncCommand(RoundButtonClick);
            RoundButtonText = AppResources.Click;
        }
        #region Services
        private readonly IMvxNavigationService mvxNavigationService;
        #endregion
        public override void ViewAppearing() {
            base.ViewAppearing();
            RoundButtonText = AppResources.Click;
        }

        #region Commands
        public IMvxCommand RoundButtonClickCommand { get; private set; }

        private async Task RoundButtonClick() {
            ShowLoadingBarCommand?.Execute();
            await Task.Run(RoundButtonAsync);
            HideLoadingBarCommand?.Execute();
        }

        private async Task RoundButtonAsync() {
            Thread.Sleep(3000);
            RoundButtonText = AppResources.Clicked;
            await mvxNavigationService.Navigate<ListViewModel>();
        }

        #endregion

        #region Properties

        public string _roundButtonText;
        public string RoundButtonText {
            get => _roundButtonText;
            set => SetProperty(ref _roundButtonText, value);
        }

        public override string Title => "Home View";
        #endregion
    }
}
