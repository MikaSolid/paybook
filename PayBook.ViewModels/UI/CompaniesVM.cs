﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class CompaniesVM : BaseViewVM
    {
        //private readonly ICollectionView _collectionView;
        protected ObservableCollection<CompanyVM> _partysInternal = new ObservableCollection<CompanyVM>();
        private readonly ReadOnlyObservableCollection<CompanyVM> _partys;

        [ImportingConstructor]
        public CompaniesVM(IModelService modelService)
            : base(modelService)
        {
            Title = "Dobavljači";

            _partys = new ReadOnlyObservableCollection<CompanyVM>(_partysInternal);
            
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

        public ReadOnlyObservableCollection<CompanyVM> Partys
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

            var partys = _modelService.GetSuppliers();

            foreach (var party in partys)
            {
                var partyVM = new CompanyVM(party);
                partyVM.Payments = _modelService.GetPayments().Where(p => p.PartyId == party.Id).Select(p => new PaymentVM(p)).ToList();
                partyVM.Bills = _modelService.GetBills().Where(b => b.PartyId == party.Id).Select(b => new BillVM(b, null)).ToList();
                _partysInternal.Add(partyVM);
            }
        }

        public void Filter()
        {
           // _collectionView.Refresh();
            OnPropertyChanged("Partys");
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