using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayBook.DataAccess.Ef;
using PayBook.Model;
using InvoiceItem = PayBook.Model.InvoiceItem;

namespace PayBook.Test
{
    [TestClass]
    public class ServiceTests
    {
        [TestMethod]
        public void TestCreateSupplier()
        {
            var service = new EfModelService();

            var model = new Model.Supplier();
            model.Name = DateTime.Now.Millisecond.ToString();
            service.SaveSupplier(model);
        }

        [TestMethod]
        public void TestNewInvoice()
        {
            var service = new EfModelService();

            var invoice = Model.Invoice.Create(InvoiceType.PurchaseInvoice);

            var suppliers = service.GetSuppliers();

            var supplier = suppliers.FirstOrDefault();

            invoice.PartyId = supplier.Id;

            invoice.Items = new List<InvoiceItem> { new InvoiceItem { Amount = 7200, Description = "Test" } };

            service.SaveInvoice(invoice);
        }
    }
}
