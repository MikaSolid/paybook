using System.ComponentModel.Composition;
using System.Linq;

using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class UnpayedBillsVM : BillsVM
    {
        [ImportingConstructor]
        public UnpayedBillsVM(IModelService modelService)
            : base(modelService)
        {
            Title = "Neplaćeni računi";

            //_collectionView.GroupDescriptions.Add(new PropertyGroupDescription("PartyName"));

            //if (IsInDesignMode) LoadModel();
        }

        public override void LoadModel()
        {
            _billsInternal.Clear();

            var bills = _modelService.GetBills();

            foreach (var bill in bills)
            {
                var billVM = new BillVM(bill, this);

                var party = _modelService.GetParty(bill.PartyId);

                var partyVM = new CompanyVM(party);

                partyVM.Payments = _modelService.GetPayments().Where(p => p.PartyId == party.Id).Select(p => new PaymentVM(p)).ToList();
                partyVM.Bills = _modelService.GetBills().Where(b => b.PartyId == party.Id).Select(b => new BillVM(b, this)).ToList();

                billVM.Company = partyVM;

                if (party != null)
                    billVM.PartyName = party.Name;

                if (billVM.IsPayed) continue;

                if (!billVM.IsDue) continue;

                _billsInternal.Add(billVM);
            }

            Refresh();
        }

        //public ICommand ToggleAllCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(arg =>
        //        {

        //            foreach (var b in _bills)
        //            {
        //                b.IsMarkedForPayment = !b.IsMarkedForPayment;
        //                b.IsMarkedForPayment = _bills.First().IsMarkedForPayment;
        //            }
        //        });
        //    }
        //}

        //public ICommand PayCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(arg =>
        //        {
        //            foreach (var b in _bills.Where(b => b.IsMarkedForPayment))
        //            {
        //                b.IsPayed = true;

        //                var payment = new Payment();
        //                payment.Id = 0;
        //                payment.BillId = b.Id;
        //                payment.Amount = b.Amount;
        //                payment.PartyId = b.PartyId;
        //                payment.Date = DateTime.Now;
                        
        //                ModelService.SavePayment(payment);
        //            }

        //            LoadModel();

        //            Invalidate();
        //        });
        //    }
        //}

        public decimal SelectedAmount
        {
            get
            {
                return _bills.Where(b => b.IsMarkedForPayment).Sum(b => b.Amount);
            }
        }
    }
}