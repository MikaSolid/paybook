using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Validation;
using System.Linq;
using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public class EfModelService : IModelService
    {
        // This line must exist in order to wire up EF sql provider services
        SqlProviderServices _services = SqlProviderServices.Instance;

        public List<Model.Invoice> GetPurchaseInvoices()
        {
            var db = new LocalDatabase();
            return db.Invoices.ToModel().ToList();
        }

        public List<Model.Company> GetCompanies()
        {
            var db = new LocalDatabase();
            return db.Companies.ToModel().ToList();
        }

        public List<Model.Payment> GetPayments()
        {
            var db = new LocalDatabase();
            return new List<Model.Payment>();
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

            var email = company.Organization.Party.PartyContactMechanism.SingleOrDefault(e => e.ContactMechanism.EmailAddress != null);

            if (email == null)
            {
                email = new PartyContactMechanism();
                email.ContactMechanism = new ContactMechanism();
                email.Party = company.Organization.Party;
                email.ContactMechanism.EmailAddress = new EmailAddress();
                company.Organization.Party.PartyContactMechanism.Add(email);
            }

            email.ContactMechanism.EmailAddress.Address = model.Email;

            var phone = company.Organization.Party.PartyContactMechanism.SingleOrDefault(e => e.ContactMechanism.Phone != null);

            if (phone == null)
            {
                phone = new PartyContactMechanism();
                phone.ContactMechanism = new ContactMechanism();
                phone.Party = company.Organization.Party;
                phone.ContactMechanism.Phone = new Phone();
                company.Organization.Party.PartyContactMechanism.Add(phone);
            }

            phone.ContactMechanism.Phone.Number = model.Phone;

            var postalAddress = company.Organization.Party.PartyContactMechanism.SingleOrDefault(e => e.ContactMechanism.PostalAddress != null);

            if (postalAddress == null)
            {
                postalAddress = new PartyContactMechanism();
                postalAddress.ContactMechanism = new ContactMechanism();
                postalAddress.Party = company.Organization.Party;
                postalAddress.ContactMechanism.PostalAddress = new PostalAddress();
                company.Organization.Party.PartyContactMechanism.Add(postalAddress);
            }

            postalAddress.ContactMechanism.PostalAddress.Address1 = model.Address1;
            postalAddress.ContactMechanism.PostalAddress.Address2 = model.Address2;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }

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

            invoice.PartyId = model.Company.Id;

            invoice.InvoiceDate = model.Date;

            db.SaveChanges();

            invoice.UpdateItems(model.Items);


            db.SaveChanges();

            return invoice.Id;
        }

        public Model.Company GetCompany(int id)
        {
            var db = new LocalDatabase();
            return db.Companies.Single(s => s.Id == id).ToModel();
        }

        public Model.Invoice GetInvoice(int id)
        {
            var db = new LocalDatabase();
            return db.Invoices.Single(i => i.Id == id).ToModel();
        }

        public List<CompanyInfo> GetCompanyInfos()
        {
            var db = new LocalDatabase();
            return db.Companies.ToModelInfo().ToList();
        }
    }
}
