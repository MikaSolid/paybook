using System.Collections.Generic;
using System.Linq;
using PayBook.Model;
using System.Windows.Input;

namespace PayBook.ViewModels
{
    public class PartyVM : BaseVM
    {
        private readonly Party _party;
        private List<BillVM> _bills = new List<BillVM>();
        private List<PaymentVM> _payments = new List<PaymentVM>();

        public PartyVM(Party party)
        {
            _party = party;
        }

        public string Code
        {
            get
            {
                return _party.Code;
            }
            set
            {
                if (_party.Code == value) return;
                _party.Code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Name
        {
            get
            {
                return _party.Name;
            }
            set
            {
                if (_party.Name == value) return;
                _party.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Account
        {
            get
            {
                return _party.Account;
            }
            set
            {
                if (_party.Account == value) return;
                _party.Account = value;
                OnPropertyChanged("Account");
            }
        }

        public List<BillVM> Bills
        {
            get { return _bills; }
            set { _bills = value; }
        }

        public List<PaymentVM> Payments
        {
            get { return _payments; }
            set { _payments = value; }
        }

        public decimal TotalAmountPayed
        {
            get
            {
                return Payments.Sum(p => p.Amount);
            }
        }

        public decimal TotalAmountBilled
        {
            get
            {
                return Bills.Sum(p => p.Amount);
            }
        }

        public decimal Balance
        {
            get
            {
                return TotalAmountPayed - TotalAmountBilled;
            }
        }

        public bool IsBalanceDue
        {
            get
            {
                return Balance > 0;
            }
        }

        public bool IsBalanceOverDue
        {
            get
            {
                return Balance < 0;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(a =>
                {
                    Container.GetInstance().Resolve<ShellVM>().Navigate(new PartyEditorVM(_party));
                });
            }
        }
    }
}