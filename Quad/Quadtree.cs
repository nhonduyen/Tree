namespace Quad
{
    public class Quadtree
    {
        private const int Capacity = 4;
        private readonly Rectangle boundary;
        private readonly List<Point> points;
        private bool divided;

        private Quadtree northWest;
        private Quadtree northEast;
        private Quadtree southWest;
        private Quadtree southEast;

        public Quadtree(Rectangle boundary)
        {
            this.boundary = boundary;
            points = new List<Point>();
            divided = false;
        }

        public bool Insert(Point point)
        {
            if (!boundary.Contains(point))
                return false;

            if (points.Count < Capacity && !divided)
            {
                points.Add(point);
                return true;
            }

            if (!divided)
                Subdivide();

            return northWest.Insert(point) || northEast.Insert(point) ||
                   southWest.Insert(point) || southEast.Insert(point);
        }

        private void Subdivide()
        {
            double x = boundary.X;
            double y = boundary.Y;
            double w = boundary.Width / 2;
            double h = boundary.Height / 2;

            northWest = new Quadtree(new Rectangle(x, y, w, h));
            northEast = new Quadtree(new Rectangle(x + w, y, w, h));
            southWest = new Quadtree(new Rectangle(x, y + h, w, h));
            southEast = new Quadtree(new Rectangle(x + w, y + h, w, h));

            divided = true;
        }

        public List<Point> Query(Rectangle range)
        {
            List<Point> found = new List<Point>();

            if (!boundary.Intersects(range))
                return found;

            foreach (Point point in points)
            {
                if (range.Contains(point))
                    found.Add(point);
            }

            if (divided)
            {
                found.AddRange(northWest.Query(range));
                found.AddRange(northEast.Query(range));
                found.AddRange(southWest.Query(range));
                found.AddRange(southEast.Query(range));
            }

            return found;
        }
    }
}