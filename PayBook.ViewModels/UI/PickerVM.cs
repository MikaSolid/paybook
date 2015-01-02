using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PayBook.ViewModels
{
    public class PickerVM : BaseViewVM
    {
        private readonly BaseViewVM _hostView;
        private readonly ReadOnlyObservableCollection<IItemVM> _items;
        private readonly ObservableCollection<IItemVM> _itemsInternal;

        public PickerVM(BaseViewVM hostView, IEnumerable<IItemVM> items)
        {
            _hostView = hostView;
            _itemsInternal = new ObservableCollection<IItemVM>(items);
            _items = new ReadOnlyObservableCollection<IItemVM>(_itemsInternal);

            Title = "Presek stanja";
        }

        public override void LoadModel()
        {
        }

        public BaseViewVM HostView { get { return _hostView; } }

        public ReadOnlyObservableCollection<IItemVM> Items
        {
            get { return _items; }
        }
    }
}