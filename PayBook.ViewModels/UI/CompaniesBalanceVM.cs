using System.ComponentModel.Composition;
using System.Linq;
using PayBook.Model;

namespace PayBook.ViewModels
{
    [Export]
    public class CompaniesBalanceVM : CompaniesVM
    {
        [ImportingConstructor]
        public CompaniesBalanceVM(IModelService modelService)
            : base(modelService)
        {
            Title = "Presek stanja";
        }

        public override void LoadModel()
        {
            _partysInternal.Clear();

            var partys = _modelService.GetCompanies();

            foreach (var party in partys)
            {
                var partyVM = new CompanyVM(party);

                partyVM.Payments = _modelService.GetPayments().Where(p => p.PartyId == party.Id).Select(p => new PaymentVM(p)).ToList();
                partyVM.Bills = _modelService.GetPurchaseInvoices().Where(b => b.Company.Id == party.Id).Select(b => new InvoiceVM(b, null)).ToList();

                //if (partyVM.Bills.Any() || partyVM.Payments.Any())
                //    _partysInternal.Add(partyVM);
            }
        }
    }
}