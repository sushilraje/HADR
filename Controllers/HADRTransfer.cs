using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HADRTransfer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HADRTransfer : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<HADRTransfer> _logger;

        public HADRTransfer(ILogger<HADRTransfer> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<HADRTranfer> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new HADRTranfer
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
