namespace AVL
{
    public class AVLTree
    {
        private AVLNode root;

        private int Height(AVLNode node)
        {
            return node == null ? 0 : node.Height;
        }

        private int BalanceFactor(AVLNode node)
        {
            return node == null ? 0 : Height(node.Left) - Height(node.Right);
        }

        private void UpdateHeight(AVLNode node)
        {
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

        public void Insert(int value)
        {
            root = InsertRecursive(root, value);
        }

        private AVLNode InsertRecursive(AVLNode node, int value)
        {
            if (node == null)
                return new AVLNode(value);

            if (value < node.Value)
                node.Left = InsertRecursive(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRecursive(node.Right, value);
            else
                return node; // Duplicate values are not allowed

            UpdateHeight(node);

            int balance = BalanceFactor(node);

            // Left Left Case
            if (balance > 1 && value < node.Left.Value)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && value > node.Right.Value)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && value > node.Left.Value)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && value < node.Right.Value)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        public void InOrderTraversal()
        {
            InOrderTraversalRecursive(root);
            Console.WriteLine();
        }

        private void InOrderTraversalRecursive(AVLNode node)
        {
            if (node != null)
            {
                InOrderTraversalRecursive(node.Left);
                Console.Write($"{node.Value} ");
                InOrderTraversalRecursive(node.Right);
            }
        }

        public bool Search(int value)
        {
            return SearchRecursive(root, value);
        }

        private bool SearchRecursive(AVLNode node, int value)
        {
            if (node == null)
                return false;

            if (value == node.Value)
                return true;

            if (value < node.Value)
                return SearchRecursive(node.Left, value);
            else
                return SearchRecursive(node.Right, value);
        }
    }
}
