﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvcdemo.Controllers
{
    public class V2Controller : ApiController
    {
        [Route("rest/hello")]
        // [HttpGet]
        public string Get()
        {
            return "Hello!";
        }
    }
}
