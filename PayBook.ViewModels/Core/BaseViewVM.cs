using PayBook.Model;

namespace PayBook.ViewModels
{
    public abstract class BaseViewVM : BaseVM
    {
        protected readonly IModelService _modelService;
        private string _title;

        public string Title
        {
            get { return _title; }
            protected set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        protected BaseViewVM(IModelService modelService)
        {
            _modelService = modelService;
        }

        public abstract void LoadModel();

        //public RelayCommand NavigateTo(BaseViewVM view)
        //{
        //    return new RelayCommand(a =>
        //        {
        //            Shell.Navigate(view);
        //        });
        //}

        //private ICommand _navigateToHub;

        //public ICommand NavigateToHub
        //{
        //    get
        //    {
        //        return _navigateToHub = _navigateToHub ??
        //           new RelayCommand(
        //               p => Shell.Navigate(new HubVM()),
        //               p => !(this is HubVM));
        //    }
        //}


        //public ShellVM Shell
        //{
        //    get
        //    {
        //        return Container.GetInstance().Resolve<ShellVM>();
        //    }
        //}

        public virtual bool CanNavigateBack
        {
            get { return true; }
        }
    }
}