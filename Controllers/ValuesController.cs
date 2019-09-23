using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Healthcheck.Models;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using RestSharp;

namespace Api_Healthcheck.Controllers
{
    [Route("api")]
    [ApiController]
    [Produces("application/json")]
    public class ValuesController : Controller
    {
        private readonly ApiDbContext _context;
        public Dictionary<string, string > ApiDict1
        {
            get;
            set;
        }
        public Dictionary<string, string> ApiDict2
        {
            get;
            set;
        }
        public ValuesController(ApiDbContext context)
        {
            _context = context;
        }
        // GET api/values
        //[Route("key")]
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2"  };
        //}
        // GET api/values/5
        // [HttpGet("{Id}")]

        [Route("key/{Id}")]
        [HttpGet] 
        public JsonResult Get(int Id)
        {
            var result = _context.Tests.Where(x => x.Id == Id).FirstOrDefault();
            //var client = new RestClient("https://localhost:44372/health_check");
            //var request = new RestRequest(Method.GET);

            //request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("Connection", "keep-alive");
            //request.AddHeader("Accept-Encoding", "gzip, deflate");
            //request.AddHeader("Host", "localhost:44372");
            //request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Accept", "*/*");
            //request.AddHeader("User-Agent", "PostmanRuntime/7.15.2");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);


            //Console.WriteLine("print this please" + Response.StatusCode);
           
            return Json(new
            {
                data = result
        });             

        }


        [Route("keys")]
        // POST api/keys
        [HttpPost]
        public void Post([FromBody] Test test)
        {         
            _context.Add(test);
            _context.SaveChanges();
          
        }
        [HttpGet]
        [Route("~/health_check")]
        public JsonResult health_check()
        {
            //var result = _context.Apies;
            var client1 = new RestClient("https://localhost:44372/api/keys");
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("cache-control", "no-cache");
            request1.AddHeader("Connection", "keep-alive");
            request1.AddHeader("Accept-Encoding", "gzip, deflate");
            request1.AddHeader("Host", "localhost:44372");
            request1.AddHeader("Cache-Control", "no-cache");
            request1.AddHeader("Accept", "*/*");
            request1.AddHeader("User-Agent", "PostmanRuntime/7.15.2");
            request1.AddHeader("Content-Type", "application/json");
            IRestResponse response11 = client1.Execute(request1);
            var s1 = response11.StatusCode.ToString();

            ApiDict1["Id"] = "1";
            ApiDict1["Name"] = "key";
            ApiDict1["StatusCode"] = s1;


            var client2 = new RestClient("https://localhost:44372/api/key/1");
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("cache-control", "no-cache");
            request2.AddHeader("Connection", "keep-alive");
            request2.AddHeader("Accept-Encoding", "gzip, deflate");
            request2.AddHeader("Host", "localhost:44372");
            request2.AddHeader("Cache-Control", "no-cache");
            request2.AddHeader("Accept", "*/*");
            request2.AddHeader("User-Agent", "PostmanRuntime/7.15.2");
            request2.AddHeader("Content-Type", "application/json");
            IRestResponse response22 = client2.Execute(request2);
            var s2 = response22.StatusCode.ToString();
            ApiDict2["Id"] = "2";
            ApiDict2["Name"] = "keys";
            ApiDict2["StatusCode"] = s2;

            return Json(new
            {
                data = ApiDict1,ApiDict2
            });
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
