using System;
using System.Collections.Generic;

namespace PayBook.Model
{
    public interface IModelService
    {
        List<Bill> GetBills();

        List<Party> GetPartys();

        List<Payment> GetPayments();

        void SaveParty(Party party);

        void SaveBill(Bill bill);

        void SavePayment(Payment payment);

        Party GetParty(string partyName);

        Party GetParty(Guid guid);
    }
}