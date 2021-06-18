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
    [Route("Graph/{id}/edges")]
    public class EdgeController : ControllerBase
    {        
        // private readonly ILogger<NodeController> _logger;        

        public EdgeController()
        {
            // _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEdges(Guid id)
        {
            foreach (var g in DB.db.Values) {//Graph g in 
                if (g.Key == id) {
                    return Ok(g.Edges);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult NewEdge(Guid id)
        {
            Edge e = new Edge();
            foreach (var g in DB.db.Values) {//Graph g in 
                if (g.Key == id) {
                    g.addNode(e);
                    return Ok();
                }
            }
            return NotFound();
        }
        [HttpGet("{id2}")]
        public IActionResult GetEdge(Guid id,int id2)
        {
            foreach (var g in DB.db.Values) {//Graph g in 
                if (g.Key == id)
                {
                    g.Edges.ver(id2);
                }
            }
            return NotFound();
        }
        
    }
}
