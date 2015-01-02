using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PayBook.Model;

namespace PayBook.WebApplication.Controllers
{
    public class SalesInvoiceController : BaseApiController
    {
        // GET api/values
        public IEnumerable<SalesInvoice> Get()
        {
            return _service.GetPurchaseInvoices().Cast<SalesInvoice>();
        }

        // GET api/values/5
        public SalesInvoice Get(int id)
        {
            return (SalesInvoice)_service.GetInvoice(id);
        }

        // POST api/values
        public void Post([FromBody] SalesInvoice value)
        {
            _service.SaveInvoice(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] SalesInvoice value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}