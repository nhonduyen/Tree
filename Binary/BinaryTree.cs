namespace Binary
{
    public class BinaryTree
    {
        public TreeNode Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        // Method to insert a new node
        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private TreeNode InsertRecursive(TreeNode current, int value)
        {
            if (current == null)
            {
                return new TreeNode(value);
            }

            if (value < current.Value)
            {
                current.Left = InsertRecursive(current.Left, value);
            }
            else if (value > current.Value)
            {
                current.Right = InsertRecursive(current.Right, value);
            }

            return current;
        }

        // Method to perform an in-order traversal
        public void InOrderTraversal()
        {
            InOrderTraversalRecursive(Root);
        }

        private void InOrderTraversalRecursive(TreeNode node)
        {
            if (node != null)
            {
                InOrderTraversalRecursive(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversalRecursive(node.Right);
            }
        }

        // Method to search for a value
        public bool Contains(int value)
        {
            return ContainsRecursive(Root, value);
        }

        private bool ContainsRecursive(TreeNode current, int value)
        {
            if (current == null)
            {
                return false;
            }

            if (value == current.Value)
            {
                return true;
            }

            return value < current.Value
                ? ContainsRecursive(current.Left, value)
                : ContainsRecursive(current.Right, value);
        }
    }
}
