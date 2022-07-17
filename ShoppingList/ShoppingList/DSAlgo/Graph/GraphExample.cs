namespace ShoppingList.DSAlgo.Graph
{
    public class GraphExample<T>
    {
        public GraphExampleNode<T> Nodes { get; set; }
    }

    public class GraphExampleNode<T>
    {
        public T Data { get; set; }

        public bool Visited { get; set; } = false;

        public bool Marked { get; set; } = false;

        public GraphExampleNode<T>[] Adjacent { get; set; }
    }

    public static class GraphExampleNodeExtensions
    {


        public static void DepthFirstSearch<T>(GraphExampleNode<T> node, Action<T> action) {
            if (node == null)
                return;

            action(node.Data); // visit root node
            node.Visited = true;

            foreach(GraphExampleNode<T> n in node.Adjacent)
            {
                if (!n.Visited)
                {
                    DepthFirstSearch(n, action); // Recursively search through each node
                }
            }
        }

        public static void BreathFirstSearch<T>(GraphExampleNode<T> root, Action<T> action)
        {
            Queue<GraphExampleNode<T>> queue = new();
            root.Marked = true;

            queue.Enqueue(root); // Add root to the queue

            while(queue.Count != 0)
            {
                GraphExampleNode<T> node = queue.Dequeue();
                action(node.Data); // visit node

                foreach (GraphExampleNode<T> n in node.Adjacent)
                {
                    if (!n.Marked)
                    {
                        n.Marked = true;
                        queue.Enqueue((GraphExampleNode<T>)n);
                    }
                }
            }
        }

        public static T BreathFirstSearch<T>(GraphExampleNode<T> root, Func<GraphExampleNode<T>, bool> condition)
        {
            Queue<GraphExampleNode<T>> queue = new();
            root.Marked = true;

            queue.Enqueue(root); // Add root to the queue

            while (queue.Count != 0)
            {
                GraphExampleNode<T> node = queue.Dequeue();
                if (condition(node))
                {
                    return node.Data;
                }

                foreach (GraphExampleNode<T> n in node.Adjacent)
                {
                    if (!n.Marked)
                    {
                        n.Marked = true;
                        queue.Enqueue((GraphExampleNode<T>)n);
                    }
                }
            }

            return default(T);
        }
    }
}
