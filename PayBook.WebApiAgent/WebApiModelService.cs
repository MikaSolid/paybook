using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayBook.Model;

namespace PayBook.WebApiAgent
{
    public class WebApiModelService : IModelService
    {
        private readonly string _baseServiceUrl;

        public WebApiModelService()
        {
            _baseServiceUrl = Properties.Settings.Default.PayBookWebApiUrl;

            if (_baseServiceUrl == null)
                throw new Exception("Web Api baseServiceUrl should be defined in .config");
        }

        public List<Invoice> GetPurchaseInvoices()
        {
            return Get<List<PurchaseInvoice>>("PurchaseInvoice").Cast<Invoice>().ToList();
        }

        #region Company

        public List<Company> GetCompanies()
        {
            return Get<List<Company>>("Company");
        }

        public Invoice GetInvoice(int id)
        {
            return Get<PurchaseInvoice>("PurcaseInvoice");
        }

        public List<CompanyInfo> GetCompanyInfos()
        {
            return Get<List<CompanyInfo>>("CompanyInfo");
        }


        public Company GetCompany(int id)
        {
            return Get<Company>(String.Format("Company/{0}", id));
        }

        public int SaveCompany(Company party)
        {
            Post("Company", party);
            return party.Id;
        }

        #endregion

        public List<Payment> GetPayments()
        {
            // throw new System.NotImplementedException();
            return new List<Payment>();
        }


        public void SaveBill(Invoice invoice)
        {
            throw new System.NotImplementedException();
        }

        public void SavePayment(Payment payment)
        {
            throw new System.NotImplementedException();
        }

        public Company GetParty(string partyName)
        {
            throw new System.NotImplementedException();
        }

        public Company GetParty(int guid)
        {
            throw new System.NotImplementedException();
        }

        public int SaveInvoice(Invoice model)
        {
            Post("PurchaseInvoice", model as PurchaseInvoice);
            return model.Id;
        }

        #region Private methods

        private T Get<T>(string url) where T : new()
        {
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(new Uri(_baseServiceUrl + url)).Result;
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        private async Task<T> GetAsync<T>(string url) where T : new()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(new Uri(_baseServiceUrl + url));
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        private bool Post<T>(string url, T entity) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(_baseServiceUrl + url, entity).Result;

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        private async Task<bool> PostAsync<T>(string url, T entity) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync(_baseServiceUrl + url, entity);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        private async Task<bool> Put<T>(string url, T entity) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync(_baseServiceUrl + url, entity);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        private async Task<bool> Delete(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(new Uri(_baseServiceUrl + url));
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        #endregion
    }
}