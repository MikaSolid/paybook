using System;
using System.Collections.Generic;

namespace PayBook.Model
{
    public class DesignTimeModelService : IModelService
    {
        public List<Invoice> GetBills()
        {
            var bills = new List<Invoice>();

            for (int i = 0; i < 20; i++)
            {
                //bills.Add(Invoice.Create(InvoiceType.SalesInvoice) { Code = "5753", Date = DateTime.Now, DueDate = DateTime.Now.AddDays(5), Amount = 123 }));
                //bills.Add(new PurchaseInvoice() { Code = "3337", Date = DateTime.Now.AddDays(-10), DueDate = DateTime.Now.AddDays(-5), Amount = 456 });
                //bills.Add(new PurchaseInvoice() { Code = "1954", Date = DateTime.Now.AddMonths(-2), DueDate = DateTime.Now.AddDays(-25), Amount = 789 });
            }

            return bills;
        }

        public List<Supplier> GetSuppliers()
        {
            var partys = new List<Supplier>();
            for (int i = 0; i < 20; i++)
            {
                partys.Add(new Supplier() { Name = "Bambi", Account = "134-2345-44", Code = "001623" });
                partys.Add(new Supplier() { Name = "Marbo", Account = "211-13432235-12", Code = "002772" });
                partys.Add(new Supplier() { Name = "Vele Tabak", Account = "231-33211345", Code = "012 - 224" });

            }

            return partys;
        }

        public void SaveCompany(Company party)
        {
        }


        public void SaveBill(Invoice invoice)
        {
        }


        public Company GetParty(string partyName)
        {
            return new Company { Id = 0 };
        }


        public Company GetParty(int guid)
        {
            return new Company { Name = "Mock name" };
        }

        public int SaveSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public int SaveInvoice(Invoice model)
        {
            throw new NotImplementedException();
        }

        public Supplier GetSupplier(int id)
        {
            throw new NotImplementedException();
        }


        public List<Payment> GetPayments()
        {
            var payments = new List<Payment>();

            for (int i = 0; i < 20; i++)
            {
                payments.Add(new Payment() { Date = DateTime.Now, Amount = 3000 });
                payments.Add(new Payment() { Date = DateTime.Now.AddDays(-10), Amount = 5000 });
                payments.Add(new Payment() { Date = DateTime.Now.AddMonths(-2), Amount = 6000 });
            }

            return payments;
        }

        public void SavePayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
