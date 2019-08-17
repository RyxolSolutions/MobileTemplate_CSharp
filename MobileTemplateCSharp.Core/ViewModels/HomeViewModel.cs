using System;
using System.Threading;
using System.Threading.Tasks;
using MobileTemplateCSharp.Core.Localization;
using MobileTemplateCSharp.Core.ViewModels.Base;
using MvvmCross.Commands;

namespace MobileTemplateCSharp.Core.ViewModels {
    public class HomeViewModel : BaseViewModel {
        public HomeViewModel() {

            RoundButtonClickCommand = new MvxAsyncCommand(RoundButtonClick, RoundButtonClick_CanExecute);
            RoundButtonText = AppResources.Click;
        }

        #region Commands
        public IMvxCommand RoundButtonClickCommand { get; private set; }

        private async Task RoundButtonClick() {
            ShowLoadingBarCommand?.Execute();
            await Task.Run(() => {
                Thread.Sleep(3000);
                RoundButtonText = AppResources.Clicked;
            });
            HideLoadingBarCommand?.Execute();
        }

        private bool RoundButtonClick_CanExecute() {
            return RoundButtonText == AppResources.Click;
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
