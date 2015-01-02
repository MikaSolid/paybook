using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class CompaniesVM : BaseViewVM
    {
        protected ObservableCollection<CompanyInfo> _partysInternal = new ObservableCollection<CompanyInfo>();

        [ImportingConstructor]
        public CompaniesVM(IModelService modelService)
            : base(modelService)
        {
            Title = "Dobavljači";

            //_collectionView = CollectionViewSource.GetDefaultView(_partys);

            //_collectionView.Filter = delegate(object obj)
            //{
            //    var isCodeFiltered = !String.IsNullOrEmpty(CodeFilter);
            //    var isNameFiltered = !String.IsNullOrEmpty(NameFilter);
            //    var isAccountFiltered = !String.IsNullOrEmpty(AccountFilter);

            //    var party = obj as CompanyVM;

            //    if (party == null) return false;

            //    int codeIndex = -1;
            //    int nameIndex = -1;
            //    int accountIndex = -1;

            //    if (isCodeFiltered)
            //        codeIndex = party.Code.IndexOf(CodeFilter, 0, StringComparison.InvariantCultureIgnoreCase);

            //    if (isNameFiltered)
            //        nameIndex = party.Name.IndexOf(NameFilter, 0, StringComparison.InvariantCultureIgnoreCase);

            //    if (isAccountFiltered)
            //        accountIndex = party.Account.IndexOf(AccountFilter, 0, StringComparison.InvariantCultureIgnoreCase);

            //    return (!isCodeFiltered || codeIndex > -1)
            //        && (!isNameFiltered || nameIndex > -1)
            //        && (!isAccountFiltered || accountIndex > -1);
            //};
            // LoadModel();
        }

        public ObservableCollection<CompanyInfo> Partys
        {
            get { return _partysInternal; }
        }


        private string _codeFilter;

        public string CodeFilter
        {
            get { return _codeFilter; }
            set
            {
                if (_codeFilter == value) return;
                _codeFilter = value;
                OnPropertyChanged(() => CodeFilter);
                Filter();
            }
        }
        private string _accountFilter;

        public string AccountFilter
        {
            get { return _accountFilter; }
            set
            {
                if (_accountFilter == value) return;
                _accountFilter = value;
                OnPropertyChanged(() => AccountFilter);
                Filter();
            }
        }
        private string _nameFilter;


        public string NameFilter
        {
            get { return _nameFilter; }
            set
            {
                if (_nameFilter == value) return;
                _nameFilter = value;
                OnPropertyChanged(() => NameFilter);
                Filter();
            }
        }


        public override void LoadModel()
        {
            _partysInternal.Clear();
            _partysInternal = new ObservableCollection<CompanyInfo>(_modelService.GetCompanyInfos());
            OnPropertyChanged(() => Partys);
        }

        public void Filter()
        {
            // _collectionView.Refresh();
            OnPropertyChanged(() => Partys);
        }

        //public ICommand NavigateToPartyEditor
        //{
        //    get
        //    {
        //        return NavigateTo(new CompanyEditorVM(new Company()));
        //    }
        //}

        //private ICommand _addParty;

        //public ICommand AddPartyCommand
        //{
        //    get
        //    {
        //        return _addParty = _addParty ??
        //            new RelayCommand(
        //                p => AddParty(),
        //                p => CanAddParty);
        //    }
        //}

        public void AddParty()
        {

            _modelService.SaveCompany(new Company { Code = CodeFilter, Name = NameFilter, Account = AccountFilter });
            CodeFilter = null;
            NameFilter = null;
            AccountFilter = null;

            LoadModel();

            Filter();
        }

        public bool CanAddParty
        {
            get
            {
                //if (!_collectionView.Cast<object>().Any()
                //    && !String.IsNullOrEmpty(CodeFilter)
                //    && !String.IsNullOrEmpty(NameFilter)
                //    && !String.IsNullOrEmpty(AccountFilter))
                //{
                //    return true;
                //}

                return false;
            }
        }


        //public ICommand SortCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(arg => _collectionView.Sort(arg as string));
        //    }
        //}
    }
}