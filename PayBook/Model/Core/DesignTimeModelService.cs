using System;
using System.Collections.Generic;

namespace PayBook.Model
{
    public class DesignTimeModelService : IModelService
    {
        public List<Bill> GetBills()
        {
            var bills = new List<Bill>();

            for (int i = 0; i < 20; i++)
            {
                bills.Add(new Bill() { Code = "5753", Date = DateTime.Now, DueDate = DateTime.Now.AddDays(5), Amount = 123 });
                bills.Add(new Bill() { Code = "3337", Date = DateTime.Now.AddDays(-10), DueDate = DateTime.Now.AddDays(-5), Amount = 456 });
                bills.Add(new Bill() { Code = "1954", Date = DateTime.Now.AddMonths(-2), DueDate = DateTime.Now.AddDays(-25), Amount = 789 });
            }

            return bills;
        }

        public List<Party> GetPartys()
        {
            var partys = new List<Party>();
            for (int i = 0; i < 20; i++)
            {
                partys.Add(new Party() { Name = "Bambi", Account = "134-2345-44", Code = "001623" });
                partys.Add(new Party() { Name = "Marbo", Account = "211-13432235-12", Code = "002772" });
                partys.Add(new Party() { Name = "Vele Tabak", Account = "231-33211345", Code = "012 - 224" });

            }

            return partys;
        }

        public void SaveParty(Party party)
        {
        }


        public void SaveBill(Bill bill)
        {
        }


        public Party GetParty(string partyName)
        {
            return new Party { Id = Guid.Empty };
        }


        public Party GetParty(Guid guid)
        {
            return new Party { Name = "Mock name" };
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
