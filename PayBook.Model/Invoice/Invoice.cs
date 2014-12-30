using System;
using System.Collections.Generic;
using System.Linq;

namespace PayBook.Model
{
    public abstract class Invoice
    {

        #region Private members

        private List<InvoiceItem> _items = new List<InvoiceItem>();
        private List<InvoiceRole> _invoiceRoles = new List<InvoiceRole>();
        private List<InvoiceStatus> _invoiceStatus = new List<InvoiceStatus>();

        #endregion

        #region Constructors and Factory methods

        internal Invoice() { }

        public static Invoice Create(InvoiceType type)
        {
            Invoice invoice = type == InvoiceType.SalesInvoice ? (Invoice)new SalesInvoice() : new PurchaseInvoice();
            invoice.AddStatus(InvoiceStatusType.New);
            return invoice;
        }

        public static Invoice Create(InvoiceType type, Company party)
        {
            var invoice = Create(type);
            invoice.Company = party;
            return invoice;
        }

        #endregion

        #region Properties
        public int Id { get; set; }

        public Company Company { get; private set; }

        public DateTime? Date { get; set; }

        public DateTime? DueDate { get; set; }

        public List<InvoiceRole> InvoiceRoles
        {
            get { return _invoiceRoles; }
            set { _invoiceRoles = value; }
        }

        public List<InvoiceStatus> InvoiceStatus
        {
            get { return _invoiceStatus; }
            set { _invoiceStatus = value; }
        }

        public decimal Amount { get { return Items.Sum(i => i.Amount); } }

        public string Code { get; set; }

        public bool IsPayed { get; set; }

        public List<InvoiceItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        #endregion

        public void AddStatus(InvoiceStatusType status)
        {
            InvoiceStatus.Add(new InvoiceStatus
            {
                DateTime = DateTime.Now,
                Invoice = this,
                Status = status
            });
        }

        public void SetCompany(Company company)
        {
            Company = company;
        }

        public void SetAmount(string amount)
        {
            var val = Convert.ToDecimal(amount);

            InvoiceItem item =  _items.FirstOrDefault();

            if (item == null)
            {
                item = new InvoiceItem();
                _items.Add(item);
            }

            item.Amount = val;
        }
    }
}