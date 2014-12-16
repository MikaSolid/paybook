using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.Generic;

using PayBook.Model;

namespace PayBook.ViewModels
{
    public class BillsVM : BaseViewVM
    {
        protected ICollectionView _collectionView;
        protected readonly ObservableCollection<BillVM> _billsInternal = new ObservableCollection<BillVM>();
        protected readonly ReadOnlyObservableCollection<BillVM> _bills;
        private List<Party> _partys;

        public BillsVM()
        {
            Title = "Računi";

            _bills = new ReadOnlyObservableCollection<BillVM>(_billsInternal);

            _collectionView = CollectionViewSource.GetDefaultView(_bills);

            _collectionView.Filter = FilterBill;

            if (IsInDesignMode) LoadModel();
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

            if (isPartyFiltered && bill.PartyId != Guid.Empty && bill.PartyName != null)
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
                return ModelService.GetPartys().Select(v => v.Name).ToList();
            }
        }

        public override void LoadModel()
        {
            _billsInternal.Clear();

            var bills = ModelService.GetBills();

            foreach (var bill in bills)
            {
                var billVM = new BillVM(bill, this);

                var party = ModelService.GetParty(bill.PartyId);

                var partyVM = new PartyVM(party);

                partyVM.Payments = ModelService.GetPayments().Where(p => p.PartyId == party.Id).Select(p => new PaymentVM(p)).ToList();
                partyVM.Bills = ModelService.GetBills().Where(b => b.PartyId == party.Id).Select(b => new BillVM(b, this)).ToList();

                billVM.Party = partyVM;

                if (party != null)
                    billVM.PartyName = party.Name;

                _billsInternal.Add(billVM);
            }

            Refresh();
        }

        protected void Refresh()
        {
            _collectionView.Refresh();

            OnPropertyChanged("Bills");
        }

        public ICommand NavigateToBillEditor
        {
            get
            {
                return NavigateTo(new BillEditorVM(new Bill()));
            }
        }

        private ICommand _addBill;

        public ICommand AddBillCommand
        {
            get
            {
                return _addBill = _addBill ??
                    new RelayCommand(
                        p => AddBill(),
                        p => CanAddBill);
            }
        }

        public void AddBill()
        {
            string partyName = PartyName;

            var party = ModelService.GetParty(partyName);

            ModelService.SaveBill(
                new Bill
                {
                    PartyId = party.Id,
                    Code = Number,
                    Amount = Convert.ToDecimal(Amount),
                    Date = Convert.ToDateTime(Date),
                    DueDate = Convert.ToDateTime(DueDate),
                });

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
                if (!_collectionView.Cast<object>().Any()
                    && !String.IsNullOrEmpty(PartyName)
                    && !String.IsNullOrEmpty(Number)
                    && !String.IsNullOrEmpty(Date)
                    && !String.IsNullOrEmpty(Amount))
                {
                    return true;
                }

                return false;
            }
        }

        public ICommand FillInParty
        {
            get
            {
                return new RelayCommand(arg =>
                {
                    var e = arg as KeyEventArgs;

                    if (e.Key == Key.Enter)
                    {
                        //var party = ModelService.GetParty(PartyIdFilter);

                    }
                });
            }
        }

        public ICommand SortCommand
        {
            get
            {
                return new RelayCommand(arg => _collectionView.Sort(arg as string));
            }
        }

        internal void Invalidate()
        {
            OnPropertyChanged("SelectedAmount");
        }
    }
}