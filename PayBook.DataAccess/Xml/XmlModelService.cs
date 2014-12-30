using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using PayBook.Model;
using PayBook.Model.Core;

namespace PayBook.DataAccess
{
    public class XmlModelService : IModelService
    {
#if DEBUG
        private static string _relativePath =
            AppDomain.CurrentDomain.RelativeSearchPath != null
                ? AppDomain.CurrentDomain.RelativeSearchPath
                : AppDomain.CurrentDomain.BaseDirectory;
#endif

#if !DEBUG
        private static string _relativePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
#endif
        public const string PartysXmlPath = "Partys.xml";
        public const string BillsXmlPath = "Bills.xml";
        public const string PaymentsXmlPath = "Payments.xml";

        private readonly XDocument _partysXml;
        private readonly XDocument _billsXml;
        private readonly XDocument _paymentsXml;


        private List<Company> _partys;
        private List<Invoice> _bills;
        private List<Payment> _payments;

        public XmlModelService()
        {
            var partysPath = Path.Combine(_relativePath, PartysXmlPath);

            if (!File.Exists(partysPath))
            {
                _partysXml = new XDocument();
                _partysXml.Add(new XElement("Partys"));
                _partysXml.Save(partysPath);
                _partysXml = XDocument.Load(partysPath);

                int no = 1;

                foreach (var myString in ModelBootstrapper.Partys.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var i = myString.IndexOfFirstLowerCase();

                    var party = new Company
                    {
                        Code = no.ToString(),
                        Id = 0,
                        TaxNumber = myString.Substring(0, 9),
                        Name =
                            i > 10
                                ? myString.Substring(10, i - 12).ToPascalCase()
                                : myString.Remove(0, 10).ToPascalCase(),
                        Account = "000-0000-00",
                        Address1 = i > 0 ? myString.Remove(0, i - 2) : String.Empty
                    };

                    no++;

                    SaveCompany(party);
                }
            }

            _partysXml = XDocument.Load(partysPath);

            var billsPath = Path.Combine(_relativePath, BillsXmlPath);

            if (!File.Exists(billsPath))
            {
                _billsXml = new XDocument();
                _billsXml.Add(new XElement("Bills"));
                _billsXml.Save(billsPath);
            }

            _billsXml = XDocument.Load(billsPath);

            var paymentsPath = Path.Combine(_relativePath, PaymentsXmlPath);

            if (!File.Exists(paymentsPath))
            {
                _paymentsXml = new XDocument();
                _paymentsXml.Add(new XElement("Payments"));
                _paymentsXml.Save(paymentsPath);
            }

            _paymentsXml = XDocument.Load(paymentsPath);
        }

        private T GetModel<T>(XElement xmlElement) where T : new()
        {
            T t = new T();

            foreach (var p in t.GetType().GetProperties())
            {
                switch (p.PropertyType.Name)
                {
                    case "Guid":
                        var value = xmlElement.GetAttributeValue(p.Name);
                        if (value != null)
                            p.SetValue(t, new Guid(value), null);
                        break;
                    case "DateTime":
                        p.SetValue(t, Convert.ToDateTime(xmlElement.GetAttributeValue(p.Name)), null);
                        break;
                    case "Int32":
                        p.SetValue(t, Convert.ToInt32(xmlElement.GetAttributeValue(p.Name)), null);
                        break;
                    case "String":
                        p.SetValue(t, xmlElement.GetAttributeValue(p.Name), null);
                        break;
                    case "Decimal":
                        p.SetValue(t, Convert.ToDecimal(xmlElement.GetAttributeValue(p.Name)), null);
                        break;
                    case "Boolean":
                        p.SetValue(t, Convert.ToBoolean(xmlElement.GetAttributeValue(p.Name)), null);
                        break;
                }
            }
            return t;
        }

        private List<Invoice> Bills
        {
            get
            {
                if (_bills == null)
                {
                    _bills = new List<Invoice>();

                    var billsXml = _billsXml.Element("Bills").Elements("Bill");

                    foreach (var billXml in billsXml)
                    {
                        //_bills.Add(GetModel<Invoice>(billXml));
                    }
                }

                return _bills;
            }
        }

        public List<Invoice> GetBills()
        {
            return Bills;
        }

        private List<Company> Partys
        {
            get
            {
                if (_partys == null)
                {
                    _partys = new List<Company>();

                    var partysXml = _partysXml.Element("Partys").Elements("Party");

                    foreach (var partyXml in partysXml)
                    {
                        _partys.Add(GetModel<Company>(partyXml));
                    }
                }

                return _partys;
            }
        }

        public List<Company> GetCompanies()
        {
            throw new NotImplementedException();
            //return Partys;
        }

        private List<Payment> Payments
        {
            get
            {
                if (_payments == null)
                {
                    _payments = new List<Payment>();

                    var paymentsXml = _paymentsXml.Element("Payments").Elements("Payment");

                    foreach (var paymentXml in paymentsXml)
                    {
                        _payments.Add(GetModel<Payment>(paymentXml));
                    }
                }

                return _payments;
            }
        }

        public List<Payment> GetPayments()
        {
            return Payments;
        }

        public int SaveCompany(Company party)
        {
            bool isNew = party.Id == 0;

            var partysXml = _partysXml.Element("Partys");

            XElement partyXml;

            if (isNew)
            {
                party.Id = 0;
                partyXml = new XElement("Party");
                partysXml.Add(partyXml);
            }
            else
                partyXml = partysXml.Elements("Party").Single(p => Convert.ToInt32(p.GetAttributeValue("Id").ToString()) == party.Id);

            partyXml.SetAttributeValue("Id", party.Id);
            partyXml.SetAttributeValue("Code", party.Code);
            partyXml.SetAttributeValue("Name", party.Name);
            partyXml.SetAttributeValue("Account", party.Account);
            partyXml.SetAttributeValue("TaxNumber", party.TaxNumber);
            partyXml.SetAttributeValue("CompanyNumber", party.CompanyNumber);
            partyXml.SetAttributeValue("Address1", party.Address1);
            partyXml.SetAttributeValue("Address2", party.Address2);
            partyXml.SetAttributeValue("ContactPerson", party.ContactPerson);
            partyXml.SetAttributeValue("Email", party.Email);
            partyXml.SetAttributeValue("Phone", party.Phone);

            _partysXml.Save(Path.Combine(_relativePath, PartysXmlPath));

            if (_partys != null && isNew)
                _partys.Add(party);

            return party.Id;
        }

        public void SaveBill(Invoice invoice)
        {
            var billsXml = _billsXml.Element("Bills");

            XElement billXml;

            if (invoice.Id == 0)
            {
                billXml = new XElement("Bill");

                billsXml.Add(billXml);

                if (_bills != null)
                    _bills.Add(invoice);
            }
            else
            {
                billXml = billsXml.Elements("Bill").Single(b => Convert.ToInt32(b.GetAttributeValue("Id")) == invoice.Id);
            }

            billXml.SetAttributeValue("Id", invoice.Id);
            billXml.SetAttributeValue("Code", invoice.Code);
            billXml.SetAttributeValue("Date", invoice.Date);
            billXml.SetAttributeValue("DueDate", invoice.DueDate);
            billXml.SetAttributeValue("PartyId", invoice.PartyId);
            billXml.SetAttributeValue("Amount", invoice.Amount);
            billXml.SetAttributeValue("IsPayed", invoice.IsPayed);


            _billsXml.Save(Path.Combine(_relativePath, BillsXmlPath));
        }

        public Company GetParty(string partyName)
        {
            var party = Partys.FirstOrDefault(v => v.Name == partyName);

            if (party == null)
            {
                party = new Company();
                party.Id = 0;
                party.Name = partyName;

                SaveCompany(party);
            }

            return party;
        }

        public Company GetParty(int guid)
        {
            return Partys.SingleOrDefault(v => v.Id == guid);
        }

        public int SaveInvoice(Invoice model)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public List<CompanyInfo> GetCompanyInfos()
        {
            throw new NotImplementedException();
        }

        public void SavePayment(Payment payment)
        {
            var paymentsXml = _paymentsXml.Element("Payments");

            var paymentXml = new XElement("Payment");

            paymentXml.Add(new XAttribute("Id", payment.Id));
            paymentXml.Add(new XAttribute("BillId", payment.BillId));
            paymentXml.Add(new XAttribute("Date", payment.Date));
            paymentXml.Add(new XAttribute("PartyId", payment.PartyId));
            paymentXml.Add(new XAttribute("Amount", payment.Amount));

            paymentsXml.Add(paymentXml);

            _paymentsXml.Save(Path.Combine(_relativePath, PaymentsXmlPath));

            if (_payments != null)
                _payments.Add(payment);
        }
    }
}