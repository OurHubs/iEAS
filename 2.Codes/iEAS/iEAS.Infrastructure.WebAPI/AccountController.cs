using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace iEAS.Infrastructure.WebAPI
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> CheckUser()
        {
            return new List<string>
            {
                "ABC",
                "DEF",
                "GHI",
                "AAA"
            };
        }
    }
}