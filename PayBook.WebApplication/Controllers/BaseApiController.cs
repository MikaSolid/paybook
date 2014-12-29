using System.Web.Http;
using PayBook.DataAccess;
using PayBook.DataAccess.Ef;
using PayBook.Model;

namespace PayBook.WebApplication.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly IModelService _service;

        public BaseApiController()
        {
            _service = new EfModelService();
        }
    }
}