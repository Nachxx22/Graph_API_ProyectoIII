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
    [Route("Graph/nodes")]
    public class NodeController : ControllerBase
    {        
        // private readonly ILogger<NodeController> _logger;        

        public NodeController()
        {
            // _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        
    }
}
