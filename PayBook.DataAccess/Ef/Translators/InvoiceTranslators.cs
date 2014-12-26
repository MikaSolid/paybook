﻿using System.Collections.Generic;
using System.Linq;
using PayBook.Model;

namespace PayBook.DataAccess.Ef
{
    public static class InvoiceTranslators
    {
        public static Model.Invoice ToModel(this Invoice dataModel)
        {
            var salesInvoice = dataModel.RoleType.Description == "Sales Invoice"
                ? InvoiceType.SalesInvoice
                : InvoiceType.PurchaseInvoice;


            var model = Model.Invoice.Create(salesInvoice);

            model.Id = dataModel.Id;
            model.PartyId = dataModel.PartyId;
            model.Date = dataModel.InvoiceDate;

            return model;
        }

        public static IEnumerable<Model.Invoice> ToModel(this IEnumerable<Invoice> dataModel)
        {
            return dataModel.Select(dm => dm.ToModel());
        }

        public static InvoiceItem FromModel(this Model.InvoiceItem dataModel, Invoice invoice)
        {
            var model = new InvoiceItem();
            model.Id = dataModel.Id;
            model.Invoice = invoice;
            model.Amount = dataModel.Amount;
            model.Description= dataModel.Description;
            return model;
        }

        public static IEnumerable<InvoiceItem> FromModel(this IEnumerable<Model.InvoiceItem> model, Invoice invoice)
        {
            return model.Select(i => i.FromModel(invoice));
        }

        public static void UpdateItems(this Invoice dbInvoice, IEnumerable<Model.InvoiceItem> items)
        {
            foreach (var item in items)
            {
                var dbItem = dbInvoice.InvoiceItems.FirstOrDefault(i => i.Id == item.Id);

                if (dbItem == null)
                {
                    dbItem = new InvoiceItem();
                    dbItem.Invoice = dbInvoice;
                    dbInvoice.InvoiceItems.Add(dbItem);
                }

                dbItem.Amount = item.Amount;
                dbItem.Description = item.Description;
            }
        }
    }
}
