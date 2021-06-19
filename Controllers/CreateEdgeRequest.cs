namespace graph_api.Controllers
{
    public class CreateEdgeRequest
    {
        public int startNode { get; set; }
        public int endNode { get; set; }
        public int weight { get; set; }
    }
}