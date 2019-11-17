using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManipulator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DbManipulator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleRegistryController : Controller
    {
        private readonly ILogger<PeopleRegistryController> _logger;
        private readonly MariadbtestContext _dbContext;
        private readonly LinkGenerator _linkGenerator;

        public PeopleRegistryController(ILogger<PeopleRegistryController> logger, MariadbtestContext dbContext, LinkGenerator linkGenerator)
        {
            _logger = logger;
            _dbContext = dbContext;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var res = await _dbContext.Test.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return NotFound();
            }

            var result = new Person
            {
                Id = res.Id,
                Name = res.Name,
                Text = res.Text,
                Time = res.Time
            };

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] Person person)
        {
            var testRecord = new Test
            {
                Name = person.Name,
                Time = DateTime.Now,
                Text = person.Text
            };

            var res = await _dbContext.Test.AddAsync(testRecord);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            // todo generate correct link
            //var url = Url.ActionLink("GetAsync", "PeopleRegistry", new {id = res.Entity.Id});

            return Created($"https://localhost/test", testRecord);
        }
    }
}
