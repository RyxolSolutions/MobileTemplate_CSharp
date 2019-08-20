using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MobileTemplateCSharp.Core.Models.Cells;
using MobileTemplateCSharp.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MobileTemplateCSharp.Core.ViewModels.Fragments {
    public class ListFragmentViewModel : ListViewModel {
        public ListFragmentViewModel(IMvxNavigationService mvxNavigationService) : base(mvxNavigationService) {
        }

        public IMvxAsyncCommand _reloadListCommand;
        public IMvxAsyncCommand ReloadListCommand => _reloadListCommand =
            _reloadListCommand ?? new MvxAsyncCommand(LoadItems);

        protected override async Task LoadItems() {
            ShowLoadingBarCommand?.Execute();
            await Task.Run(async () => {
                Thread.Sleep(2000);
                await base.LoadItems();
            });
            HideLoadingBarCommand.Execute();
        }

        public override string Title => "List Fragment";
        public override string ButtonTitle => "Reload List";
    }
}
