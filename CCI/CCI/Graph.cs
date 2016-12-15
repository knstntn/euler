namespace CCI
{
    public class Graph
    {
        public GraphNode[] Nodes { get; set; }
    }

    public class GraphNode
    {
        public string Value { get; set; }
        public GraphNode[] Children { get; set; }
    }
}