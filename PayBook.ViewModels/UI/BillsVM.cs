﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class BillsVM : BaseViewVM
    {
        protected readonly ObservableCollection<BillVM> _billsInternal = new ObservableCollection<BillVM>();
        protected readonly ReadOnlyObservableCollection<BillVM> _bills;
        private List<Company> _partys;

        [ImportingConstructor]
        public BillsVM(IModelService modelService)
            : base(modelService)
        {
            Title = "Računi";

            _bills = new ReadOnlyObservableCollection<BillVM>(_billsInternal);

            // if (IsInDesignMode) LoadModel();
        }

        public bool FilterBill(object obj)
        {
            var isNumberFiltered = !String.IsNullOrEmpty(Number);
            var isDateFiltered = !String.IsNullOrEmpty(Date);
            var isPartyFiltered = !String.IsNullOrEmpty(PartyName);
            var isDueDateFiltered = !String.IsNullOrEmpty(DueDate);

            var bill = obj as BillVM;

            if (bill == null) return false;

            int numberIndex = -1;
            bool dateIndex = false;
            bool dueDateIndex = false;
            int partyIndex = -1;

            if (isNumberFiltered)
            {
                numberIndex = bill.Number.IndexOf(Number, 0, StringComparison.InvariantCultureIgnoreCase);
            }

            if (isDateFiltered)
            {
                DateTime date;
                if (DateTime.TryParse(Date, out date))
                    dateIndex = bill.Date == date;
            }

            if (isDueDateFiltered)
            {
                DateTime dueDate;
                if (DateTime.TryParse(DueDate, out dueDate))
                    dueDateIndex = bill.DueDate == dueDate;
            }

            if (isPartyFiltered && bill.PartyId != 0 && bill.PartyName != null)
                partyIndex = bill.PartyName.IndexOf(PartyName, 0, StringComparison.InvariantCultureIgnoreCase);



            return (!isNumberFiltered || numberIndex > -1)
            && (!isDateFiltered || dateIndex)
            && (!isDueDateFiltered || dueDateIndex)
            && (!isPartyFiltered || partyIndex > -1);
        }

        public ReadOnlyObservableCollection<BillVM> Bills
        {
            get { return _bills; }
        }

        private string _partyName;

        public string PartyName
        {
            get { return _partyName; }
            set
            {
                if (_partyName == value) return;
                _partyName = value;
                OnPropertyChanged("PartyName");
                Refresh();
            }
        }

        private string _number;

        public string Number
        {
            get { return _number; }
            set
            {
                if (_number == value) return;
                _number = value;
                OnPropertyChanged("Number");
                Refresh();
            }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set
            {
                if (_date == value) return;
                _date = value;
                OnPropertyChanged("Date");
                Refresh();
            }
        }

        private string _amount;

        public string Amount
        {
            get { return _amount; }
            set
            {
                if (_amount == value) return;
                _amount = value;
                OnPropertyChanged("Amount");
                Refresh();
            }
        }

        private string _dueDate;

        public string DueDate
        {
            get { return _dueDate; }
            set
            {
                if (_dueDate == value) return;
                _dueDate = value;
                OnPropertyChanged("DueDate");
                Refresh();
            }
        }

        public List<string> Partys
        {
            get
            {
                return _modelService.GetCompanies().Select(v => v.Name).ToList();
            }
        }

        public override void LoadModel()
        {
            _billsInternal.Clear();

            var bills = _modelService.GetBills();

            foreach (var bill in bills)
            {
                var billVM = new BillVM(bill, this);

                var party = _modelService.GetCompany(bill.PartyId);

                var partyVM = new CompanyVM(party);

                partyVM.Payments = _modelService.GetPayments().Where(p => p.PartyId == party.Id).Select(p => new PaymentVM(p)).ToList();
                partyVM.Bills = _modelService.GetBills().Where(b => b.PartyId == party.Id).Select(b => new BillVM(b, this)).ToList();

                billVM.Company = partyVM;

                if (party != null)
                    billVM.PartyName = party.Name;

                _billsInternal.Add(billVM);
            }

            Refresh();
        }

        protected void Refresh()
        {
           // _collectionView.Refresh();

            OnPropertyChanged("Bills");
        }

        //public ICommand NavigateToBillEditor
        //{
        //    get
        //    {
        //        return NavigateTo(new BillEditorVM(Invoice.Create(InvoiceType.PurchaseInvoice)));
        //    }
        //}

        //private ICommand _addBill;

        //public ICommand AddBillCommand
        //{
        //    get
        //    {
        //        return _addBill = _addBill ??
        //            new RelayCommand(
        //                p => AddBill(),
        //                p => CanAddBill);
        //    }
        //}

        public void AddBill()
        {
            string partyName = PartyName;

            var party = _modelService.GetParty(partyName);

            var invoice = Invoice.Create(InvoiceType.PurchaseInvoice);
            invoice.PartyId = party.Id;
            invoice.Code = Number;
            invoice.Items.Add(new InvoiceItem { Amount = Convert.ToDecimal(Amount) });
            invoice.Date = Convert.ToDateTime(Date);
            invoice.DueDate = Convert.ToDateTime(DueDate);

            _modelService.SaveBill(invoice);

            PartyName = null;
            Number = null;
            Date = null;
            DueDate = null;
            Amount = null;

            LoadModel();
        }

        public bool CanAddBill
        {
            get
            {
                //if (!_collectionView.Cast<object>().Any()
                //    && !String.IsNullOrEmpty(PartyName)
                //    && !String.IsNullOrEmpty(Number)
                //    && !String.IsNullOrEmpty(Date)
                //    && !String.IsNullOrEmpty(Amount))
                //{
                //    return true;
                //}

                return false;
            }
        }

        //public ICommand FillInParty
        //{
        //    get
        //    {
        //        return new RelayCommand(arg =>
        //        {
        //            var e = arg as KeyEventArgs;

        //            if (e.Key == Key.Enter)
        //            {
        //                //var party = ModelService.GetParty(PartyIdFilter);

        //            }
        //        });
        //    }
        //}

        //public ICommand SortCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(arg => _collectionView.Sort(arg as string));
        //    }
        //}

        internal void Invalidate()
        {
            OnPropertyChanged("SelectedAmount");
        }
    }
}