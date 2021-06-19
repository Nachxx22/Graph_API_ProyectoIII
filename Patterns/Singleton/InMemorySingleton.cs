using graph_api.Entities;

namespace graph_api.Controllers.Patterns.Singleton
{
    public class InMemorySingleton 
    { 
        private readonly object _lock = new object();

        private Entities.LinkedList<Graph> _graphs;
        public Entities.LinkedList<Graph> Graphs
        {
            get
            {
                lock (_lock)
                {
                    if (_graphs == null)
                    {
                        _graphs = new Entities.LinkedList<Graph>();
                    }

                    return _graphs;
                }
            }
        }  

        public void ClearGraph()
        {
            _graphs.Clear();
        }
    }
} 