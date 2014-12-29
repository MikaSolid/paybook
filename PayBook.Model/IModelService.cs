using System.Collections.Generic;

namespace PayBook.Model
{
    public interface IModelService
    {
        List<Invoice> GetBills();

        List<Supplier> GetSuppliers();

        List<Payment> GetPayments();

        void SaveCompany(Company party);

        void SaveBill(Invoice invoice);

        void SavePayment(Payment payment);

        Company GetParty(string partyName);

        Company GetParty(int guid);

        int SaveSupplier(Supplier model);

        int SaveInvoice(Invoice model);
        
        Supplier GetSupplier(int id);
    }
}