
using RedBlack.Enums;

namespace RedBlack
{
    public class RBNode
    {
        public int Value { get; set; }
        public Color Color { get; set; }
        public RBNode Left { get; set; }
        public RBNode Right { get; set; }
        public RBNode Parent { get; set; }

        public RBNode(int value)
        {
            Value = value;
            Color = Color.Red;
        }
    }
}
