using System.Linq;

namespace PayBook.ViewModels
{
    public class CompaniesBalanceVM : CompaniesVM
    {
        public CompaniesBalanceVM()
        {
            Title = "Presek stanja";
        }

        public override void LoadModel()
        {
            _partysInternal.Clear();

            var partys = ModelService.GetSuppliers();

            foreach (var party in partys)
            {
                var partyVM = new CompanyVM(party);
                
                partyVM.Payments = ModelService.GetPayments().Where(p => p.PartyId == party.Id).Select(p => new PaymentVM(p)).ToList();
                partyVM.Bills = ModelService.GetBills().Where(b => b.PartyId == party.Id).Select(b => new BillVM(b, null)).ToList();

                if (partyVM.Bills.Any() || partyVM.Payments.Any())
                    _partysInternal.Add(partyVM);
            }
        }
    }
}