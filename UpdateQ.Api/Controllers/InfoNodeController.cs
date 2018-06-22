using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpdateQ.Service.Interfaces;

namespace UpdateQ.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/InfoNode")]
    public class InfoNodeController : Controller
    {
        private readonly IUserService userService;

        public InfoNodeController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/InfoNode
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: api/InfoNode/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        //// POST: api/InfoNode
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
        
        //// PUT: api/InfoNode/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
