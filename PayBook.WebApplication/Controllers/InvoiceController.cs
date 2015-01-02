using System.Collections.Generic;
using System.Web.Http;
using Invoice = PayBook.Model.Invoice;

namespace PayBook.WebApplication.Controllers
{
    public class InvoiceController : BaseApiController
    {
        // GET api/values
        public IEnumerable<Invoice> Get()
        {
            return _service.GetPurchaseInvoices();
        }

        // GET api/values/5
        public Invoice Get(int id)
        {
            return _service.GetInvoice(id);
        }

        // POST api/values
        public void Post([FromBody] Invoice value)
        {
            _service.SaveInvoice(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Invoice value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}