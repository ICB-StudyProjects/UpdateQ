using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpdateQ.Model.Entities;
using UpdateQ.Service.Interfaces;

namespace UpdateQ.Api.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<User> Get()
        {
            var users = this.userService.GetUsers();

            return users;
        }

        //// GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(Guid id)
        {
            var user = this.userService.GetUser(id);

            return user;
        }

        //// POST: api/User
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/User/5
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
