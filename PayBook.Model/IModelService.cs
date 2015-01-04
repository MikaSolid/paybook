using System.Collections.Generic;

namespace PayBook.Model
{
    public interface IModelService
    {
        List<Invoice> GetPurchaseInvoices();

        List<Company> GetCompanies();

        List<Payment> GetPayments();

        void SavePayment(Payment payment);

        Company GetParty(string partyName);

        int SaveCompany(Company model);

        int SaveInvoice(Invoice model);
        
        Company GetCompany(int id);

        Invoice GetInvoice(int id);

        List<CompanyInfo> GetCompanyInfos();
    }
}