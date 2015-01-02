namespace PayBook.ViewModels
{
    public class ItemVM : BaseVM, IItemVM
    {
        private int _id;
        private string _title;
        private bool _isSelected;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
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