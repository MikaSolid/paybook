using System.ComponentModel;
using System.Linq;
using PayBook.Model;
using System;

namespace PayBook.ViewModels
{
    public class BillVM : BaseVM
    {
        private readonly Invoice _invoice;
        private readonly BillsVM _bills;

        public BillVM(Invoice invoice, BillsVM bills)
        {
            _invoice = invoice;
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
                return _invoice.Code;
            }
            set
            {
                if (_invoice.Code == value) return;
                _invoice.Code = value;
                OnPropertyChanged("Number");
            }
        }

        private string _partyName;

        private CompanyVM _company;

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

        public int PartyId
        {
            get
            {
                return _invoice.PartyId;
            }
            set
            {
                if (_invoice.PartyId == value) return;
                _invoice.PartyId = value;
                OnPropertyChanged("PartyId");
            }
        }


        public DateTime? Date
        {
            get
            {
                return _invoice.Date;
            }
            set
            {
                if (_invoice.Date == value) return;
                _invoice.Date = value;
                OnPropertyChanged("Date");
            }
        }

        public DateTime? DueDate
        {
            get
            {
                return _invoice.DueDate;
            }
            set
            {
                if (_invoice.DueDate == value) return;
                _invoice.DueDate = value;
                OnPropertyChanged("DueDate");
            }
        }

        public decimal Amount
        {
            get
            {
                return _invoice.Amount;
            }
            set
            {
                if (_invoice.Amount == value) return;
                
                var item = _invoice.Items.FirstOrDefault();
                
                if (item != null)
                {
                    item.Amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }

        public CompanyVM Company
        {
            get { return _company; }
            set { _company = value; }
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
                return _invoice.IsPayed;
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
                _invoice.IsPayed = value;
                // Container.GetInstance().Resolve<IModelService>().SaveBill(_invoice);
                OnPropertyChanged("IsPayed");
                OnPropertyChanged("IsMarkedForPayment");
            }
        }

        public int Id { get { return _invoice.Id; } }
    }
}
