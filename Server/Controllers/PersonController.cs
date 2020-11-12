using BlazorDemo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        public PersonController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person)
        {
            Context.Add(person);
            await Context.SaveChangesAsync();
            return person.Id;
        }
    }
}
