using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PayBook.Model;

namespace PayBook.WebApplication.Controllers
{
    public class PurchaseInvoiceController : BaseApiController
    {
        // GET api/values
        public IEnumerable<PurchaseInvoice> Get()
        {
            return _service.GetInvoices().Cast<PurchaseInvoice>();
        }

        // GET api/values/5
        public Invoice Get(int id)
        {
            return _service.GetInvoice(id);
        }

        // POST api/values
        public void Post([FromBody] PurchaseInvoice value)
        {
            _service.SaveInvoice(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] PurchaseInvoice value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}