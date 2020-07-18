using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QRCode_Reader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        // GET: api/QRCode
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/QRCode/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/QRCode
        [HttpPost]
        public string Post(string value)
        {
            //string poststring = "http://localhost:44354/api/QRCode/" + value;
            string poststring = "http://goqr.me/api/doc/create-qr-code/?data=%22DipeshMalani%22";
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.UploadStringTaskAsync(new Uri("http://goqr.me/api/doc/read-qr-code/"), "POST", poststring);
            }
                return value;
        }

        // PUT: api/QRCode/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
