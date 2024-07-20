﻿namespace Quad
{
    public class Rectangle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public bool Contains(Point point)
        {
            return point.X >= X && point.X <= X + Width &&
                   point.Y >= Y && point.Y <= Y + Height;
        }

        public bool Intersects(Rectangle range)
        {
            return !(range.X > X + Width || range.X + range.Width < X ||
                     range.Y > Y + Height || range.Y + range.Height < Y);
        }
    }
}
