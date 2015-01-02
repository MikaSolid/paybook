namespace PayBook.ViewModels
{
    public class ItemVM : BaseVM, IItemVM
    {
        private int _id;
        private string _name;
        private bool _isSelected;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged(() => IsSelected);
            }
        }
    }
}