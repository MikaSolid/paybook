using System.Collections.Generic;
using System.Web.Http;
using Supplier = PayBook.Model.Supplier;

namespace PayBook.WebApplication.Controllers
{
    public class SupplierApiController : BaseApiController
    {
        // GET api/values
        public IEnumerable<Supplier> Get()
        {
            return _service.GetSuppliers();
        }

        // GET api/values/5
        public Supplier Get(int id)
        {
            return _service.GetSupplier(id);
        }

        // POST api/values
        public void Post([FromBody] Supplier value)
        {
            _service.SaveSupplier(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Supplier value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}