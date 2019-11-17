using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManipulator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbManipulator.Controllers
{
    [Route("")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly MariadbtestContext _dbContext;

        public IndexController(MariadbtestContext  dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _dbContext.Test.CountAsync();
            return Ok(new {totalRecords = result});
        }
    }
}