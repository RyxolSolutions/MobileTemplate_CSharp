using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileTemplateCSharp.Core.Models.Cells;
using MobileTemplateCSharp.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace MobileTemplateCSharp.Core.ViewModels {
    public class ListViewModel : BaseListViewModel {

        public ListViewModel(
            IMvxNavigationService mvxNavigationService
        ) {
            this.mvxNavigationService = mvxNavigationService;
        }

        #region Services
        private readonly IMvxNavigationService mvxNavigationService;
        #endregion

        public override void ViewAppeared() {
            base.ViewAppeared();
            _ = LoadItems();
        }

        protected virtual async Task LoadItems() {
            await Task.Run(() => {
                Items = new List<TitleModel>() {
                    new TitleModel() { Title = "1: i am  empty" },
                    new TitleModel() { Title = "2: i am  empty" },
                    new TitleModel() { Title = "3: i am  empty" },
                    new TitleModel() { Title = "4: i am  empty" },
                    new TitleModel() { Title = "5: i am  empty" }
                };
            });
            UpdateListUI();
        }

        #region Commnads

        private IMvxAsyncCommand _nextPageCommand;
        public IMvxAsyncCommand NextPageCommand => _nextPageCommand =
            _nextPageCommand ?? new MvxAsyncCommand(NextPage);

        private async Task NextPage() {
            await mvxNavigationService.Navigate<ContainingFragmentsViewModel>();
            await mvxNavigationService.Close(this);
        }

        #endregion

        #region List

        private List<TitleModel> _items;
        public List<TitleModel> Items {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public IMvxCommand<TitleModel> _removeItemCommand;
        public IMvxCommand<TitleModel> RemoveItemCommand => _removeItemCommand =
            _removeItemCommand ?? new MvxCommand<TitleModel>(RemoveItem);


        private void UpdateListUI() {
            if (Items.Count() == 0)
                ShowEmplyListCommand?.Execute();
            else
                HideEmplyListCommand?.Execute();
        }

        public void AddItem() {
            Items.Add(new TitleModel() { Title = $"{Items.Count() + 1}: i am empty" });
            RefreshListCommand?.Execute();
            UpdateListUI();
        }

        public void RemoveItem(TitleModel model) {
            if (model != null)
                Items.Remove(model);
            RefreshListCommand?.Execute();
            UpdateListUI();
        }

        #endregion

        #region Properties

        public virtual string ButtonTitle => "Next Page";

        public override string Title => "Empty List";

        #endregion

    }
}
