using Binary;

namespace BST
{
    public class BinarySearchTree
    {
        public TreeNode Root { get; private set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private TreeNode InsertRecursive(TreeNode root, int value)
        {
            if (root == null)
            {
                return new TreeNode(value);
            }

            if (value < root.Value)
            {
                root.Left = InsertRecursive(root.Left, value);
            }
            else if (value > root.Value)
            {
                root.Right = InsertRecursive(root.Right, value);
            }

            return root;
        }

        public bool Search(int value)
        {
            return SearchRecursive(Root, value);
        }

        private bool SearchRecursive(TreeNode root, int value)
        {
            if (root == null || root.Value == value)
                return root != null;

            if (value < root.Value)
                return SearchRecursive(root.Left, value);
            else
                return SearchRecursive(root.Right, value);
        }

        public void InOrderTraversal()
        {
            InOrderTraversalRecursive(Root);
            Console.WriteLine();
        }

        private void InOrderTraversalRecursive(TreeNode root)
        {
            if (root != null)
            {
                InOrderTraversalRecursive(root.Left);
                Console.Write(root.Value + " ");
                InOrderTraversalRecursive(root.Right);
            }
        }

        public void Delete(int value)
        {
            Root = DeleteRecursive(Root, value);
        }

        private TreeNode DeleteRecursive(TreeNode root, int value)
        {
            if (root == null) return root;

            if (value < root.Value)
                root.Left = DeleteRecursive(root.Left, value);
            else if (value > root.Value)
                root.Right = DeleteRecursive(root.Right, value);
            else
            {
                // Node with only one child or no child
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // Node with two children: Get the inorder successor (smallest in the right subtree)
                root.Value = MinValue(root.Right);

                // Delete the inorder successor
                root.Right = DeleteRecursive(root.Right, root.Value);
            }

            return root;
        }

        private int MinValue(TreeNode root)
        {
            int minv = root.Value;
            while (root.Left != null)
            {
                minv = root.Left.Value;
                root = root.Left;
            }
            return minv;
        }
    }
}
