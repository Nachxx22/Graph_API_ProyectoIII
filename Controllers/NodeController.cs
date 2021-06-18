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
    [Route("Graph/{id}/nodes")]
    public class NodeController : ControllerBase
    {        
        // private readonly ILogger<NodeController> _logger;        

        public NodeController()
        {
            // _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            foreach (var g in DB.db.Values) {//Graph g in 
                if (g.Key == id) {
                    return Ok(g.getNodes());
                }
            }
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult CreateNewNode(Guid id)
        {
            Node n = new Node();
            foreach (var g in DB.db.Values) {//Graph g in 
                if (g.Key == id) {
                    g.addNode(n);
                    return Ok();
                }
            }
            return NotFound();
        }
        [HttpGet("{id2}")]
        public IActionResult GetNode(Guid id,int id2)
        {
            foreach (var g in DB.db.Values) {//Graph g in 
                if (g.Key == id)
                {
                    g.Nodes.ver(id2);
                }
            }
            return NotFound();
        }
        
    }
}
