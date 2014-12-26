using PayBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayBook.ViewModels
{
    public class PaymentVM : BaseVM
    {
        private readonly Payment _payment;

        public PaymentVM(Payment payment)
        {
            _payment = payment;
        }

        private string _partyName;

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
                return _payment.PartyId;
            }
            set
            {
                if (_payment.PartyId == value) return;
                _payment.PartyId = value;
                OnPropertyChanged("PartyId");
            }
        }


        public DateTime Date
        {
            get
            {
                return _payment.Date;
            }
            set
            {
                if (_payment.Date == value) return;
                _payment.Date = value;
                OnPropertyChanged("Date");
            }
        }

        public decimal Amount
        {
            get
            {
                return _payment.Amount;
            }
            set
            {
                if (_payment.Amount == value) return;
                _payment.Amount = value;
                OnPropertyChanged("Amount");
            }
        }
    }
}
