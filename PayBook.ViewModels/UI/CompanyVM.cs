using System.Collections.Generic;
using System.Linq;
using PayBook.Model;

namespace PayBook.ViewModels
{
    public class CompanyVM : BaseItemVM
    {
        private readonly Company _company;
        private List<InvoiceVM> _bills = new List<InvoiceVM>();
        private List<PaymentVM> _payments = new List<PaymentVM>();

        public CompanyVM(Company company)
        {
            _company = company;
        }

        public string Code
        {
            get
            {
                return _company.Code;
            }
            set
            {
                if (_company.Code == value) return;
                _company.Code = value;
                OnPropertyChanged(() => Code);
            }
        }

        public Company Company { get { return _company; } }

        public override int Id
        {
            get { return _company.Id; }
        }

        public override string Name
        {
            get
            {
                return _company.Name;
            }
            set
            {
                if (_company.Name == value) return;
                _company.Name = value;
                OnPropertyChanged(() => Name);
            }
        }

        public string Account
        {
            get
            {
                return _company.Account;
            }
            set
            {
                if (_company.Account == value) return;
                _company.Account = value;
                OnPropertyChanged(() => Account);
            }
        }

        public List<InvoiceVM> Bills
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

        //public ICommand EditCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(a => Container.GetInstance().Resolve<ShellVM>().Navigate(new CompanyEditorVM(_party)));
        //    }
        //}
    }
}