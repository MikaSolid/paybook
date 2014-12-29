using System.Collections.Generic;
using PayBook.Model;

namespace PayBook.WebApiAgent
{
    public class WebApiModelService : WebApiProxy, IModelService
    {
        public override List<Invoice> GetBills()
        {
            //throw new System.NotImplementedException();
            return new List<Invoice>();
        }

        public override List<Supplier> GetSuppliers()
        {
            return Get<List<Supplier>>("supplierapi");
            return GetAsync<List<Supplier>>("supplierapi").Result;
        }

        public override List<Payment> GetPayments()
        {
            // throw new System.NotImplementedException();
            return new List<Payment>();
        }

        public override void SaveCompany(Company party)
        {
            throw new System.NotImplementedException();
        }

        public override void SaveBill(Invoice invoice)
        {
            throw new System.NotImplementedException();
        }

        public override void SavePayment(Payment payment)
        {
            throw new System.NotImplementedException();
        }

        public override Company GetParty(string partyName)
        {
            throw new System.NotImplementedException();
        }

        public override Company GetParty(int guid)
        {
            throw new System.NotImplementedException();
        }

        public override int SaveSupplier(Supplier model)
        {
            throw new System.NotImplementedException();
        }

        public override int SaveInvoice(Invoice model)
        {
            throw new System.NotImplementedException();
        }

        public override Supplier GetSupplier(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}