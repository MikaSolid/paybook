using PayBook.ViewModels;

namespace PayBook
{
    public abstract class BaseItemVM : BaseVM, IItemVM
    {
        private bool _isSelected;

        public abstract int Id { get; }
        public abstract string Name { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                OnPropertyChanged(() => IsSelected);
            }
        }
    }
}