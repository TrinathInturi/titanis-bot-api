using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Titanis.Api.Context;

namespace Titanis.Api.Controllers
{
    public class BaseController : ApiController
    {
        public TitanisDbContext.ApiDbContext ApiDbContext = new TitanisDbContext.ApiDbContext();
    }
}
