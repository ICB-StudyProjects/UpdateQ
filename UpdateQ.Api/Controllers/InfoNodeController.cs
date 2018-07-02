namespace UpdateQ.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UpdateQ.Model.DTOs;
    using UpdateQ.Service.Interfaces;

    [Authorize]
    [Route("api/infonode")]
    public class InfoNodeController : Controller
    {
        private readonly IInfoNodeService infoNodeService;

        public InfoNodeController(IInfoNodeService infoNodeService)
        {
            this.infoNodeService = infoNodeService;
        }

        // GET: api/InfoNode
        [HttpGet]
        //[Produces("application/json")]
        public IActionResult Get()
        {
            var infoNodes = this.infoNodeService.GetInfoNodes();

            if (infoNodes == null)
            {
                return NotFound();
            }

            var nodes = Mapper.Map<ICollection<NodesReadDTO>>(infoNodes);
            
            return Ok(nodes);
        }

        //// GET: api/InfoNode/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/InfoNode
        [HttpPost]
        public void Post([FromBody]string value)
        {
            Debug.WriteLine(value);
        }

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
