using System.Collections.Generic;
using System.Web.Http;
using Company = PayBook.Model.Company;

namespace PayBook.WebApplication.Controllers
{
    public class CompanyController : BaseApiController
    {
        // GET api/values
        public IEnumerable<Company> Get()
        {
            return _service.GetCompanies();
        }

        // GET api/values/5
        public Company Get(int id)
        {
            return _service.GetCompany(id);
        }

        // POST api/values
        public void Post([FromBody] Company value)
        {
            _service.SaveCompany(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Company value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}