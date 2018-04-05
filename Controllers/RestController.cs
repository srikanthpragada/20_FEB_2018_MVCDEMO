using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvcdemo.Controllers
{
    public class RestController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello Web API. Now it is :  " + DateTime.Now.ToString();
        }

        public string Get(string id)
        {
            return id + ", Hello Web API";
        }

        public string Get(string name, string mobile)
        {
            return name + "," + mobile;
        }
    }
}
