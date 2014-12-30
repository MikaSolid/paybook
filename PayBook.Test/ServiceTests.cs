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
        public void TestCreateCompany()
        {
            var service = new EfModelService();

            var model = new Model.Company();
            model.Name = DateTime.Now.Millisecond.ToString();
            service.SaveCompany(model);
        }

        [TestMethod]
        public void TestNewInvoice()
        {
            var service = new EfModelService();

            var invoice = Model.Invoice.Create(InvoiceType.PurchaseInvoice);

            var companys = service.GetCompanies();

            var company = companys.FirstOrDefault();

            invoice.Company.Id = company.Id;

            invoice.Items = new List<InvoiceItem> { new InvoiceItem { Amount = 7200, Description = "Test" } };

            service.SaveInvoice(invoice);
        }

        [TestMethod]
        public void TestPayBook()
        {
            var company = new Model.Company();
        }
    }
}
