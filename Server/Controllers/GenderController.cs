﻿using BlazorDemo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        public GenderController(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Gender gender)
        {
            Context.Add(gender);
            await Context.SaveChangesAsync();
            return gender.Id;
        }
    }
}
