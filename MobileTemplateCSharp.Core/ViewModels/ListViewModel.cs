using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileTemplateCSharp.Core.Models.Cells;
using MobileTemplateCSharp.Core.ViewModels.Base;
using MvvmCross.Commands;

namespace MobileTemplateCSharp.Core.ViewModels
{
    public class ListViewModel : BaseListViewModel {

        public ListViewModel() {
        }

        public override void ViewCreated() {
            base.ViewCreated();
        }

        public override void ViewAppearing() {
            base.ViewAppearing();
        }

        public override void ViewAppeared() {
            base.ViewAppeared();
            Items = new List<TitleModel>() {
                new TitleModel() { Title = "1: i am  empty" },
                new TitleModel() { Title = "2: i am  empty" },
            };
            UpdateListUI();
        }

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
        public override string Title => "Empty List";
    }
}
