using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

using PayBook.Model;

namespace PayBook.ViewModels
{
    public class PartysBalanceVM : PartysVM
    {
        public PartysBalanceVM()
            : base()
        {
            Title = "Presek stanja";
        }

        public override void LoadModel()
        {
            _partysInternal.Clear();

            var partys = ModelService.GetPartys();

            foreach (var party in partys)
            {
                var partyVM = new PartyVM(party);
                
                partyVM.Payments = ModelService.GetPayments().Where(p => p.PartyId == party.Id).Select(p => new PaymentVM(p)).ToList();
                partyVM.Bills = ModelService.GetBills().Where(b => b.PartyId == party.Id).Select(b => new BillVM(b, null)).ToList();

                if (partyVM.Bills.Any() || partyVM.Payments.Any())
                    _partysInternal.Add(partyVM);
            }
        }
    }
}