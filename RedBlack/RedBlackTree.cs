using RedBlack.Enums;

namespace RedBlack
{
    public class RedBlackTree
    {
        private RBNode root;

        private void LeftRotate(RBNode x)
        {
            RBNode y = x.Right;
            x.Right = y.Left;
            if (y.Left != null)
                y.Left.Parent = x;
            y.Parent = x.Parent;
            if (x.Parent == null)
                root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else
                x.Parent.Right = y;
            y.Left = x;
            x.Parent = y;
        }

        private void RightRotate(RBNode y)
        {
            RBNode x = y.Left;
            y.Left = x.Right;
            if (x.Right != null)
                x.Right.Parent = y;
            x.Parent = y.Parent;
            if (y.Parent == null)
                root = x;
            else if (y == y.Parent.Right)
                y.Parent.Right = x;
            else
                y.Parent.Left = x;
            x.Right = y;
            y.Parent = x;
        }

        public void Insert(int value)
        {
            RBNode node = new RBNode(value);
            RBNode y = null;
            RBNode x = root;

            while (x != null)
            {
                y = x;
                if (node.Value < x.Value)
                    x = x.Left;
                else
                    x = x.Right;
            }

            node.Parent = y;
            if (y == null)
                root = node;
            else if (node.Value < y.Value)
                y.Left = node;
            else
                y.Right = node;

            InsertFixup(node);
        }

        private void InsertFixup(RBNode z)
        {
            while (z.Parent != null && z.Parent.Color == Color.Red)
            {
                if (z.Parent == z.Parent.Parent.Left)
                {
                    RBNode y = z.Parent.Parent.Right;
                    if (y != null && y.Color == Color.Red)
                    {
                        z.Parent.Color = Color.Black;
                        y.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            LeftRotate(z);
                        }
                        z.Parent.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        RightRotate(z.Parent.Parent);
                    }
                }
                else
                {
                    RBNode y = z.Parent.Parent.Left;
                    if (y != null && y.Color == Color.Red)
                    {
                        z.Parent.Color = Color.Black;
                        y.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Left)
                        {
                            z = z.Parent;
                            RightRotate(z);
                        }
                        z.Parent.Color = Color.Black;
                        z.Parent.Parent.Color = Color.Red;
                        LeftRotate(z.Parent.Parent);
                    }
                }
            }
            root.Color = Color.Black;
        }

        public void InOrderTraversal()
        {
            InOrderTraversalRecursive(root);
            Console.WriteLine();
        }

        private void InOrderTraversalRecursive(RBNode node)
        {
            if (node != null)
            {
                InOrderTraversalRecursive(node.Left);
                Console.Write($"{node.Value}({node.Color}) ");
                InOrderTraversalRecursive(node.Right);
            }
        }
    }
}
