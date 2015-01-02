using System;
using System.Linq;
using PayBook.Model;

namespace PayBook.ViewModels
{
    public class InvoiceVM : BaseVM
    {
        private readonly Invoice _invoice;

        private readonly PurchaseInvoicesVM _invoices;

        public InvoiceVM(Invoice invoice, PurchaseInvoicesVM invoices)
        {
            _invoice = invoice;
            _invoices = invoices;
        }

        public bool IsDue
        {
            get { return DateTime.Now > DueDate; }
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

        public string PartyName
        {
            get
            {
                return _invoice.Company.Name;
            }
            set
            {
                if (_invoice.Company.Name == value) return;
                _invoice.Company.Name = value;
                OnPropertyChanged("PartyName");
            }
        }

        public int PartyId
        {
            get
            {
                return _invoice.Company.Id;
            }
            set
            {
                if (_invoice.Company.Id == value) return;
                _invoice.Company.Id = value;
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
                var firstOrDefault = _invoice.Items.FirstOrDefault();
                if (firstOrDefault != null) return firstOrDefault.Amount;
                return 0;
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

        private bool _isMarkedForPayment;

        public bool IsMarkedForPayment
        {
            get { return _isMarkedForPayment; }
            set
            {
                _isMarkedForPayment = value;
                OnPropertyChanged("IsMarkedForPayment");
                if (_invoices != null)
                    _invoices.Invalidate();
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
