using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserSimulation.Core.Models;
using UserSimulation.Core.Services.Interfaces;

namespace UserSimulation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<UserEntity> Get(int id)
        {
            return userService.GetUserById(id);
        }

        //Invoke-RestMethod https://localhost:44301/api/User -Method POST -Body (@{Id= 1; Name= "SomeName"; Surname= "SomeSurname"} | ConvertTo-Json) -ContentType "application/json"
        // POST: api/User
        [HttpPost]
        public void Post([FromBody] UserEntity entity)
        {
            userService.AddUser(entity);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserEntity entity)
        {
            userService.PutUserById(id, entity);
        }
    }
}
