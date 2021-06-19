using System; 
using System.Linq; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using graph_api.Entities;
using graph_api.Controllers.Patterns.Singleton;

namespace graph_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphsController : ControllerBase
    {        
        private readonly ILogger<GraphsController> _logger;     

        private InMemorySingleton _inMemorySingleton;
        private Entities.LinkedList<Graph> Graphs => _inMemorySingleton?.Graphs;
         

        public GraphsController(InMemorySingleton inMemorySingleton, ILogger<GraphsController> logger)
        {
            _inMemorySingleton = inMemorySingleton;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult CreateGraphs()
        {
            var newId = Graphs != null ? Graphs.Max(g => g?.Id) ?? 0 : 0;
            newId++;
            Graphs.AddLast(new Graph(newId));

            return new JsonResult(new
            {
                id = newId
            });
        }

        [HttpGet]
        public Graph[] GetGraphs()
        {
            var result = Graphs.ToArray();

            return result;
        }

        [HttpDelete]
        public IActionResult DeleteGraphs()
        {
            _inMemorySingleton.ClearGraph();

            return NoContent();
        }


        //// PUT api/<GraphsController>/5
        //[HttpPut("{id}")]
        [HttpGet("{id}")]
        public IActionResult GetGraph(int id)
        {
            if (Graphs != null)
            {
                var result = Graphs.FirstOrDefault(w => w?.Id == id);
                return result != null ?
                    new JsonResult(result) :
                    NotFound();
            }

            return NotFound();
        }

        //// PUT api/<GraphsController>/5
        //[HttpPut("{id}")]
        [HttpDelete("{id}")]
        public IActionResult DeleteGraph(int id)
        {
            if (Graphs != null)
            {
                var result = Graphs.FirstOrDefault(w => w?.Id == id);

                if (result != null)
                {
                    Graphs.Remove(result);
                    return NoContent();
                }

                return NotFound();
            }

            return NotFound();
        }

        //// PUT api/<GraphsController>/5
        //[HttpPut("{id}")]
        [HttpPost("{id}/Nodes")]
        public IActionResult CreateNode(int id, [FromBody]Entity entity)
        {
            if (Graphs != null)
            {
                var graph = Graphs.FirstOrDefault(w => w?.Id == id);

                if (graph != null)
                {
                    int newId = graph.NewNodeId();
                    graph.Nodes.AddLast(new Node(newId, entity));

                    return new JsonResult(newId);
                }
            }

            return StatusCode(404);
        }

        //// PUT api/<GraphsController>/5 
        [HttpGet("{id}/Nodes")] 
        public IActionResult GetNodes(int id)
        {
            if (Graphs != null)
            {
                var result = Graphs.FirstOrDefault(w => w?.Id == id);

                if (result != null)
                {
                    return new JsonResult(result?.Nodes);
                }
            }

            return NotFound();
        }

        //// PUT api/<GraphsController>/5 
        [HttpPut("{id}/Nodes/{nodeId}")]
        public IActionResult UpdateNode(int id, int nodeId, Entity entity)
        {
            if (Graphs != null)
            {
                var graph = Graphs.FirstOrDefault(w => w?.Id == id);
                if (graph != null)
                {
                    var node = graph.Nodes.FirstOrDefault(w => w?.Id == nodeId);
                    if (node != null)
                    {
                        graph.Nodes.Where(w => w?.Id == nodeId).ToList().ForEach(w => w.Entity = entity);
                        return Ok();
                    }
                }
            }

            return StatusCode(500);
        }

        //// PUT api/<GraphsController>/5 
        [HttpDelete("{id}/Nodes")]
        public IActionResult DeleteNode(int id)
        {

            if (Graphs != null)
            {
                var graph = Graphs.FirstOrDefault(w => w?.Id == id);
                if (graph != null)
                {
                    graph.Nodes.Clear();
                    return Ok();
                }
            }

            return StatusCode(500);
        }

        //// PUT api/<GraphsController>/5 
        [HttpDelete("{id}/Nodes/{nodeId}")]
        public IActionResult DeleteNode(int id, int nodeId)
        {
            if (Graphs != null)
            {
                var graph = Graphs.FirstOrDefault(w => w?.Id == id);
                if (graph != null)
                { 
                    if (nodeId == -1)
                    { 
                        graph.Nodes.Clear();
                        return Ok();
                    }
                    else
                    { 
                        var node = graph.Nodes.FirstOrDefault(w => w?.Id == nodeId);
                        if (node != null)
                        {
                            graph.Nodes.Remove(node);
                            return Ok();
                        }
                    }
                }
            }

            return StatusCode(500);
        }

        

        //// PUT api/<GraphsController>/5 
        [HttpGet("{id}/edges")]
        public IActionResult GetEdges(int id)
        {
            if (Graphs != null)
            {
                var result = Graphs.FirstOrDefault(w => w?.Id == id);

                if (result != null)
                {
                    return new JsonResult(result.Edges);
                }
            }

            return NotFound();
        }

        //// PUT api/<GraphsController>/5 
        [HttpDelete("{id}/edges")]
        public IActionResult DeleteEdge(int id)
        {
            try
            {
                if (Graphs != null)
                {
                    var graph = Graphs.FirstOrDefault(w => w?.Id == id);
                    if (graph != null)
                    {
                        if (graph.Edges.Any())
                        {
                            graph.Edges.Clear();
                            return Ok();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return NotFound();

        }

        //// PUT api/<GraphsController>/5 
        [HttpPost("{id}/edges")]
        public IActionResult CreateEdge(int id, [FromBody]CreateEdgeRequest input)
        {
            if (Graphs != null)
            {
                var graph = Graphs.FirstOrDefault(w => w?.Id == id);

                if (graph != null)
                {
                    int newId = graph.NewEdgeId();
                    graph.Edges.AddLast(new Edge(newId, input.startNode, input.endNode, input.weight));

                    return new JsonResult(newId);
                }
            }

            return StatusCode(404);
        }

        //// PUT api/<GraphsController>/5 
        [HttpPut("{id}/edges/{edgeId}")]
        public IActionResult UpdateEdge(int id, int edgeId, [FromBody] CreateEdgeRequest input)
        {
            if (Graphs != null)
            {
                var graph = Graphs.FirstOrDefault(w => w?.Id == id);

                if (graph != null)
                {
                    var edge = graph.Edges.FirstOrDefault(w => w?.Id == edgeId);
                    if (edge != null)
                    {
                        graph.Edges.Where(w => w?.Id == edgeId).ToList().ForEach(w => {
                            w.start = input.startNode;
                            w.end = input.endNode;
                            w.weight = input.weight;
                        });
                        return Ok();
                    }
                }
            }

            return StatusCode(404);
        }

        //// PUT api/<GraphsController>/5 
        [HttpDelete("{id}/edges/{edgeId}")]
        public IActionResult DeleteEdge(int id, int edgeId)
        {
            if (Graphs != null)
            {
                var graph = Graphs.FirstOrDefault(w => w?.Id == id);

                if (graph != null)
                {
                    var edge = graph.Edges.FirstOrDefault(w => w?.Id == edgeId);
                    if (edge != null)
                    {
                        graph.Edges.Remove(edge);
                        return Ok();
                    }
                }
            }

            return StatusCode(404);
        }

        //// PUT api/<GraphsController>/5 
        [HttpGet("{id}/degree")]
        public IActionResult GetDegree(int id, string sort = "DESC")
        {
            if (Graphs != null)
            {
                var grapf = Graphs.FirstOrDefault(w => w?.Id == id);
                return new JsonResult(grapf.GetDegree(sort));
            }
            return NotFound();
        }

        //// PUT api/<GraphsController>/5 
        [HttpGet("{id}/dijkstra")]
        public IActionResult GetDijkstra(int id, int startNode, int endNode)
        {
            if (Graphs != null)
            {
                var grapf = Graphs.FirstOrDefault(w => w?.Id == id);
                return new JsonResult(grapf.GetDijkstra(startNode, endNode));
            }
            return NotFound();
        }
    }
}
