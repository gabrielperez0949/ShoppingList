namespace ShoppingList.DSAlgo.Trees
{
    public class TreeExample
    {
        public TreeExampleNode Root { get; set; }
    }

    public class TreeExampleNode
    {
        public string Name { get; set; }
        public TreeExampleNode[] Children { get; set; }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

    }

    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }
    }

    public static class TreeExampleExtensions
    {

        public static void PrintInOrder<T>(this BinaryTree<T> tree)
        {
            InOrderTraversal<T>(tree.Root, (data) => Console.WriteLine($"this node is {data.ToString}"));
        }

        public static void InOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> action)
        {
            if(node != null)
            {
                InOrderTraversal<T>(node.Left, action);//left
                action(node.Data);
                InOrderTraversal<T>(node.Right, action);//right
            }
        }

        public static void PreOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                action(node.Data);
                PreOrderTraversal<T>(node.Left, action);//left
                PreOrderTraversal<T>(node.Right, action);//right
            }
        }

        public static void PostOrderTraversal<T>(BinaryTreeNode<T> node, Action<T> action)
        {
            if (node != null)
            {
                PostOrderTraversal<T>(node.Left, action);//left
                PostOrderTraversal<T>(node.Right, action);//right
                action(node.Data);
            }
        }
    }
}
