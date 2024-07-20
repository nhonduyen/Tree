// See https://aka.ms/new-console-template for more information
using Quad;

Console.WriteLine("Quad Tree");

Quadtree qt = new Quadtree(new Rectangle(0, 0, 100, 100));

qt.Insert(new Point(10, 10));
qt.Insert(new Point(20, 20));
qt.Insert(new Point(30, 30));
qt.Insert(new Point(40, 40));
qt.Insert(new Point(50, 50));

List<Point> found = qt.Query(new Rectangle(15, 15, 30, 30));

Console.WriteLine("Points found in range:");
foreach (Point p in found)
{
    Console.WriteLine($"({p.X}, {p.Y})");
}
