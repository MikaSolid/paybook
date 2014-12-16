using System.Linq;
using PayBook.Model;
using System;

namespace PayBook.ViewModels
{
    public class BillVM : BaseVM
    {
        private readonly Bill _bill;
        private readonly BillsVM _bills;

        public BillVM(Bill bill, BillsVM bills)
        {
            _bill = bill;
            _bills = bills;
        }

        private bool _isDue;

        public bool IsDue
        {
            get
            {
                return DateTime.Now > DueDate;
            }
            set { _isDue = value; }
        }

        public string Number
        {
            get
            {
                return _bill.Code;
            }
            set
            {
                if (_bill.Code == value) return;
                _bill.Code = value;
                OnPropertyChanged("Number");
            }
        }

        private string _partyName;

        private PartyVM _party;

        public string PartyName
        {
            get
            {
                return _partyName;
            }
            set
            {
                if (_partyName == value) return;
                _partyName = value;
                OnPropertyChanged("PartyName");
            }
        }

        public Guid PartyId
        {
            get
            {
                return _bill.PartyId;
            }
            set
            {
                if (_bill.PartyId == value) return;
                _bill.PartyId = value;
                OnPropertyChanged("PartyId");
            }
        }


        public DateTime Date
        {
            get
            {
                return _bill.Date;
            }
            set
            {
                if (_bill.Date == value) return;
                _bill.Date = value;
                OnPropertyChanged("Date");
            }
        }

        public DateTime DueDate
        {
            get
            {
                return _bill.DueDate;
            }
            set
            {
                if (_bill.DueDate == value) return;
                _bill.DueDate = value;
                OnPropertyChanged("DueDate");
            }
        }

        public decimal Amount
        {
            get
            {
                return _bill.Amount;
            }
            set
            {
                if (_bill.Amount == value) return;
                _bill.Amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public PartyVM Party
        {
            get { return _party; }
            set { _party = value; }
        }

        private bool _isMarkedForPayment;

        public bool IsMarkedForPayment
        {
            get { return _isMarkedForPayment; }
            set
            {
                _isMarkedForPayment = value;
                OnPropertyChanged("IsMarkedForPayment");
                if (_bills != null)
                    _bills.Invalidate();
            }
        }

        public bool IsPayed
        {
            get
            {
                return _bill.IsPayed;
                //return _bill.PaymentId != null && _bill.PaymentId != Guid.Empty;
                //    decimal sum = Party.TotalAmountPayed;

                //    var orderedBills = Party.Bills.OrderBy(b => b.Date.AddDays(b.PaymentDays));

                //    foreach (var bill in orderedBills)
                //    {
                //        if (sum > bill.Amount)
                //        {
                //            if (bill.Id == Id)
                //            {
                //                return true;
                //            }
                //            sum -= bill.Amount;
                //        }
                //    }

                //    return false;
                //}
            }
            set
            {
                _bill.IsPayed = value;
                Container.GetInstance().Resolve<IModelService>().SaveBill(_bill);
                OnPropertyChanged("IsPayed");
                OnPropertyChanged("IsMarkedForPayment");
            }
        }

        public Guid Id { get { return _bill.Id; } }
    }
}
