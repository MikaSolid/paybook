using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public class EfModelService : IModelService
    {
        // This line must exist in order to wire up EF sql provider services
        SqlProviderServices _services = SqlProviderServices.Instance;

        public List<Model.Invoice> GetBills()
        {
            throw new NotImplementedException();
        }

        public List<Model.Company> GetCompanies()
        {
            var db = new LocalDatabase();
            return db.Companies.ToCompany().ToList();
        }

        public List<Model.Payment> GetPayments()
        {
            var db = new LocalDatabase();
            return new List<Model.Payment>();
        }

        public void SaveBill(Model.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public void SavePayment(Model.Payment payment)
        {
            throw new NotImplementedException();
        }

        public Model.Company GetParty(string partyName)
        {
            throw new NotImplementedException();
        }

        public Model.Company GetParty(int guid)
        {
            throw new NotImplementedException();
        }


        public int SaveCompany(Model.Company model)
        {
            var db = new LocalDatabase();

            var company = db.Companies.SingleOrDefault(p => p.Id == model.Id);

            if (company == null)
            {
                company = new Company();
                company.Organization = new Organization();
                company.Organization.Party = new Party();
                db.Companies.Add(company);
            }

            company.Organization.Party.Code = model.Code;
            company.Organization.Name = model.Name;
            
            company.CompanyNumber = model.CompanyNumber;
            company.TaxNumber = model.TaxNumber;

            var bar = company.Organization.Party.BillingAccountRole;

            if (bar == null)
            {
                bar = new BillingAccountRole();
                bar.BillingAccount = new BillingAccount();
                bar.Party = company.Organization.Party;
                bar.FromDate = DateTime.Now;
                bar.ToDate = DateTime.Now;
                company.Organization.Party.BillingAccountRole = bar;
            }

            bar.BillingAccount.Description = model.Account;

            db.SaveChanges();

            return company.Id;
        }

        public int SaveInvoice(Model.Invoice model)
        {
            var db = new LocalDatabase();

            Invoice invoice = db.Invoices.SingleOrDefault(p => p.Id == model.Id);

            if (invoice == null)
            {
                invoice = new Invoice();

                invoice.RoleTypeId = model is PurchaseInvoice
                ? db.RoleTypes.Single(rt => rt.Description == "PurchaseInvoice").Id
                : db.RoleTypes.Single(rt => rt.Description == "SalesInvoice").Id;

                db.Invoices.Add(invoice);
            }

            invoice.PartyId = model.PartyId;
            invoice.InvoiceDate = model.Date;

            db.SaveChanges();

            invoice.UpdateItems(model.Items);


            db.SaveChanges();

            return invoice.Id;
        }

        public Model.Company GetCompany(int id)
        {
            var db = new LocalDatabase();
            return db.Companies.Single(s => s.Id == id).ToCompany();
        }

        public List<CompanyInfo> GetCompanyInfos()
        {
            var db = new LocalDatabase();
            return db.Companies.ToCompanyInfo().ToList();
        }
    }
}
