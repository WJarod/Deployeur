using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bouzin.Data;
using Bouzin.Models;

namespace Bouzin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BouzinController : ControllerBase
    {
        private readonly IBouzin _bouzin;

        public BouzinController(IBouzin bouzin){_bouzin = bouzin;}

        [HttpGet("start")]
        public async Task<ActionResult<string>> start()
        {
            await _bouzin.StartBouzin(new Discovery() { url = "http://localhost:5000/discovery" });

            return Ok("Bouzin started");
        }

    }
}
