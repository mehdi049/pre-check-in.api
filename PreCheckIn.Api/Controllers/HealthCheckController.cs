using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreCheckIn.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route("/")]
    public class HealthCheckController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
