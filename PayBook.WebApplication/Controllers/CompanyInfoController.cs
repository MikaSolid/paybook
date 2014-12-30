using System.Collections.Generic;
using PayBook.Model;

namespace PayBook.WebApplication.Controllers
{
    public class CompanyInfoController : BaseApiController
    {
        // GET api/values
        public IEnumerable<CompanyInfo> Get()
        {
            return _service.GetCompanyInfos();
        }
    }
}