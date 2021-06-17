using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using graph_api.Entities;

namespace graph_api.Controllers
{
    [ApiController]
    [Route("Graph/edges")]
    public class NodeController : ControllerBase
    {        
        // private readonly ILogger<NodeController> _logger;        

        public EdgeController()
        {
            // _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult NewEdge(){
        }
        
    }
}
