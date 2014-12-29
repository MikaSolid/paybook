using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayBook.Model;

namespace PayBook.WebApiAgent
{
    public abstract class WebApiProxy
    {
        private readonly string _baseServiceUrl;

        protected WebApiProxy()
        {
            _baseServiceUrl = ConfigurationManager.AppSettings["baseServiceUrl"];

            if (_baseServiceUrl == null)
                throw new Exception("Web Api baseServiceUrl should be defined in .config");
        }

        protected T Get<T>(string url) where T : new()
        {
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync(new Uri(_baseServiceUrl + url)).Result;
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        protected async Task<T> GetAsync<T>(string url) where T : new()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(new Uri(_baseServiceUrl + url));
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        protected bool Post<T>(string url, T entity) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(_baseServiceUrl + url, entity).Result;
                
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        protected async Task<bool> PostAsync<T>(string url, T entity) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync(_baseServiceUrl + url, entity);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        protected async Task<bool> Put<T>(string url, T entity) where T : new()
        {
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync(_baseServiceUrl + url, entity);
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        protected async Task<bool> Delete(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(new Uri(_baseServiceUrl + url));
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Delete failed, exception: " + response.Content);
                return true;
            }
        }

        public abstract List<Invoice> GetBills();
        public abstract List<Supplier> GetSuppliers();
        public abstract List<Payment> GetPayments();
        public abstract void SaveCompany(Company party);
        public abstract void SaveBill(Invoice invoice);
        public abstract void SavePayment(Payment payment);
        public abstract Company GetParty(string partyName);
        public abstract Company GetParty(int guid);
        public abstract int SaveSupplier(Supplier model);
        public abstract int SaveInvoice(Invoice model);
        public abstract Supplier GetSupplier(int id);
    }
}