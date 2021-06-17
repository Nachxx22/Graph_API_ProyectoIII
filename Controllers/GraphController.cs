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
    [Route("[controller]")]
    public class GraphController : ControllerBase
    {        
        private readonly ILogger<GraphController> _logger;        
        private static List<Graph> graphs = new List<Graph>();

        public GraphController(ILogger<GraphController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Graph> GetAllGraphs()
        {
            return GraphController.graphs;
        }

        [HttpGet("{id}")]
        public IActionResult GetGraph(int id)
        {
            foreach (Graph g in graphs) {
                if (g.Id == id) {
                    return Ok(g);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateNewGraph()
        {
            GraphController.graphs.Add(new Graph());
            return Ok();
        }
    }
}
