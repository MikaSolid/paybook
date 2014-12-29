using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public class EfModelService : IModelService
    {
        SqlProviderServices _services = SqlProviderServices.Instance;

        public List<Model.Invoice> GetBills()
        {
            throw new NotImplementedException();
        }

        public List<Model.Supplier> GetSuppliers()
        {
            var db = new LocalDatabase();
            return db.Suppliers.ToModel().ToList();
        }

        public List<Model.Payment> GetPayments()
        {
            var db = new LocalDatabase();
            //            return db.Invoices.ToModel().ToList();
            return new List<Model.Payment>();
        }

        public void SaveCompany(Company party)
        {
            throw new NotImplementedException();
        }

        public void SaveBill(Model.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public void SavePayment(Model.Payment payment)
        {
            throw new NotImplementedException();
        }

        public Company GetParty(string partyName)
        {
            throw new NotImplementedException();
        }

        public Company GetParty(int guid)
        {
            throw new NotImplementedException();
        }

        public int SaveSupplier(Model.Supplier model)
        {
            var db = new LocalDatabase();

            Supplier supplier = supplier = db.Suppliers.SingleOrDefault(p => p.Id == model.Id);

            if (supplier == null)
            {
                supplier = new Supplier();

                supplier.Organization = new Organization();
                supplier.Organization.Party = new Party();

                db.Suppliers.Add(supplier);
            }

            supplier.Organization.Name = model.Name;

            db.SaveChanges();

            return supplier.Id;
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

        public Model.Supplier GetSupplier(int id)
        {
            var db = new LocalDatabase();
            return db.Suppliers.Single(s => s.Id == id).ToModel();
        }
    }
}
