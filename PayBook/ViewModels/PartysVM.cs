using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

using PayBook.Model;

namespace PayBook.ViewModels
{
    public class PartysVM : BaseViewVM
    {
        private readonly ICollectionView _collectionView;
        protected ObservableCollection<PartyVM> _partysInternal = new ObservableCollection<PartyVM>();
        private readonly ReadOnlyObservableCollection<PartyVM> _partys;

        public PartysVM()
        {
            Title = "Dobavljači";

            _partys = new ReadOnlyObservableCollection<PartyVM>(_partysInternal);

            _collectionView = CollectionViewSource.GetDefaultView(_partys);

            _collectionView.Filter = delegate(object obj)
            {
                var isCodeFiltered = !String.IsNullOrEmpty(CodeFilter);
                var isNameFiltered = !String.IsNullOrEmpty(NameFilter);
                var isAccountFiltered = !String.IsNullOrEmpty(AccountFilter);

                var party = obj as PartyVM;

                if (party == null) return false;

                int codeIndex = -1;
                int nameIndex = -1;
                int accountIndex = -1;

                if (isCodeFiltered)
                    codeIndex = party.Code.IndexOf(CodeFilter, 0, StringComparison.InvariantCultureIgnoreCase);

                if (isNameFiltered)
                    nameIndex = party.Name.IndexOf(NameFilter, 0, StringComparison.InvariantCultureIgnoreCase);

                if (isAccountFiltered)
                    accountIndex = party.Account.IndexOf(AccountFilter, 0, StringComparison.InvariantCultureIgnoreCase);

                return (!isCodeFiltered || codeIndex > -1)
                    && (!isNameFiltered || nameIndex > -1)
                    && (!isAccountFiltered || accountIndex > -1);
            };

            if (IsInDesignMode) LoadModel();
        }

        public ReadOnlyObservableCollection<PartyVM> Partys
        {
            get { return _partys; }
        }


        private string _codeFilter;

        public string CodeFilter
        {
            get { return _codeFilter; }
            set
            {
                if (_codeFilter == value) return;
                _codeFilter = value;
                OnPropertyChanged("CodeFilter");
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
                OnPropertyChanged("AccountFilter");
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
                OnPropertyChanged("NameFilter");
                Filter();
            }
        }


        public override void LoadModel()
        {
            _partysInternal.Clear();

            var partys = ModelService.GetPartys();

            foreach (var party in partys)
            {
                var partyVM = new PartyVM(party);
                partyVM.Payments = ModelService.GetPayments().Where(p => p.PartyId == party.Id).Select(p => new PaymentVM(p)).ToList();
                partyVM.Bills = ModelService.GetBills().Where(b => b.PartyId == party.Id).Select(b => new BillVM(b, null)).ToList();
                _partysInternal.Add(partyVM);
            }
        }

        public void Filter()
        {
            _collectionView.Refresh();
            OnPropertyChanged("Partys");
        }

        public ICommand NavigateToPartyEditor
        {
            get
            {
                return NavigateTo(new PartyEditorVM(new Party()));
            }
        }

        private ICommand _addParty;

        public ICommand AddPartyCommand
        {
            get
            {
                return _addParty = _addParty ??
                    new RelayCommand(
                        p => AddParty(),
                        p => CanAddParty);
            }
        }

        public void AddParty()
        {

            ModelService.SaveParty(new Party { Code = CodeFilter, Name = NameFilter, Account = AccountFilter });
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
                if (!_collectionView.Cast<object>().Any()
                    && !String.IsNullOrEmpty(CodeFilter)
                    && !String.IsNullOrEmpty(NameFilter)
                    && !String.IsNullOrEmpty(AccountFilter))
                {
                    return true;
                }

                return false;
            }
        }


        public ICommand SortCommand
        {
            get
            {
                return new RelayCommand(arg => _collectionView.Sort(arg as string));
            }
        }
    }
}