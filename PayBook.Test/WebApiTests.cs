using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayBook.Model;
using PayBook.WebApiAgent;

namespace PayBook.Test
{
    [TestClass]
    public class WebApiTests
    {
        [TestMethod]
        public void TestWebApi()
        {
            var webApi = new WebApiModelService();
            IList<Company> Companys = webApi.GetCompanies();
        }
    }
}
