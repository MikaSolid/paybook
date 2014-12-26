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
    public class PaymentsVM : BaseViewVM
    {
        private readonly ICollectionView _collectionView;
        private readonly ObservableCollection<PaymentVM> _paymentsInternal = new ObservableCollection<PaymentVM>();
        private readonly ReadOnlyObservableCollection<PaymentVM> _payments;
        private List<Party> _partys;

        public PaymentsVM()
        {
            Title = "Plaćanja";

            _payments = new ReadOnlyObservableCollection<PaymentVM>(_paymentsInternal);

            _collectionView = CollectionViewSource.GetDefaultView(_payments);

            _collectionView.Filter = delegate(object obj)
            {
                return FilterPayment(obj);
            };

            if (IsInDesignMode) LoadModel();
        }

        public bool FilterPayment(object obj)
        {
            var isDateFiltered = !String.IsNullOrEmpty(Date);
            var isPartyFiltered = !String.IsNullOrEmpty(PartyName);
         
            var payment = obj as PaymentVM;

            if (payment == null) return false;

            bool  numberIndex = false;
            bool dateIndex = false;
            int partyIndex = -1;
            bool paymentDaysIndex = false;

            if (isDateFiltered)
                dateIndex = payment.Date == Convert.ToDateTime(Date);

            if (isPartyFiltered)
                partyIndex = payment.PartyName.IndexOf(PartyName, 0, StringComparison.InvariantCultureIgnoreCase);

            return (!isDateFiltered || dateIndex)
            && (!isPartyFiltered || partyIndex > -1);
        }

        public ReadOnlyObservableCollection<PaymentVM> Payments
        {
            get { return _payments; }
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
                return ModelService.GetSuppliers().Select(v => v.Name).ToList();
            }
        }

        public override void LoadModel()
        {
            _paymentsInternal.Clear();

            var payments = ModelService.GetPayments();

            foreach (var payment in payments)
            {
                var paymentVM = new PaymentVM(payment);

                var party = ModelService.GetParty(payment.PartyId);

                if (party != null)
                    paymentVM.PartyName = party.Name;

                _paymentsInternal.Add(paymentVM);
            }

            Refresh();
        }

        private void Refresh()
        {
            _collectionView.Refresh();

            OnPropertyChanged("Payments");
        }

        private ICommand _addPayment;

        public ICommand AddPaymentCommand
        {
            get
            {
                return _addPayment = _addPayment ??
                    new RelayCommand(
                        p => AddPayment(),
                        p => CanAddPayment);
            }
        }

        public void AddPayment()
        {
            string partyName = PartyName;

            var party = ModelService.GetParty(partyName);

            ModelService.SavePayment(
                new Payment
                {
                    PartyId = party.Id,
                    Amount = Convert.ToDecimal(Amount),
                    Date = Convert.ToDateTime(Date),
                });

            PartyName = null;
            Date = null;
            Amount = null;
        
            LoadModel();
        }

        public bool CanAddPayment
        {
            get
            {
                if (!String.IsNullOrEmpty(PartyName)
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
    }
}