using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PayBook.ViewModels
{
    public class HubVM : BaseViewVM
    {
        public HubVM()
        {
            Title = "Glavni meni";
        }

        public override void LoadModel()
        {
        }

        public ICommand NavigateToBills
        {
            get
            {
                return new RelayCommand(a => Shell.Navigate(new BillsVM()));
            }
        }

        public ICommand NavigateToUnpayedBills
        {
            get
            {
                return new RelayCommand(a => Shell.Navigate(new UnpayedBillsVM()));
            }
        }

        public ICommand NavigateToPartys
        {
            get
            {
                return NavigateTo(new CompaniesVM());
            }
        }

        public ICommand NavigateToPartysBalance
        {
            get
            {
                return NavigateTo(new CompaniesBalanceVM());
            }
        }

        public ICommand NavigateToPayments
        {
            get { return NavigateTo(new PaymentsVM()); }
        }

        public ICommand NavigateToCalendar
        {
            get { return NavigateTo(new CalendarVM()); }
        }

        public override bool CanNavigateBack
        {
            get
            {
                return false;
            }
        }
    }
}
