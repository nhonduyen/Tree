namespace Segment
{
    public class SegmentTree
    {
        private int[] tree;
        private int n;

        public SegmentTree(int[] arr)
        {
            n = arr.Length;
            tree = new int[4 * n]; // The size of the tree array is typically 4 times the input array size
            BuildTree(arr, 0, 0, n - 1);
        }

        private void BuildTree(int[] arr, int node, int start, int end)
        {
            if (start == end)
            {
                tree[node] = arr[start];
                return;
            }

            int mid = (start + end) / 2;
            BuildTree(arr, 2 * node + 1, start, mid);
            BuildTree(arr, 2 * node + 2, mid + 1, end);

            tree[node] = tree[2 * node + 1] + tree[2 * node + 2];
        }

        public void Update(int index, int value)
        {
            UpdateTree(0, 0, n - 1, index, value);
        }

        private void UpdateTree(int node, int start, int end, int index, int value)
        {
            if (start == end)
            {
                tree[node] = value;
                return;
            }

            int mid = (start + end) / 2;
            if (index <= mid)
                UpdateTree(2 * node + 1, start, mid, index, value);
            else
                UpdateTree(2 * node + 2, mid + 1, end, index, value);

            tree[node] = tree[2 * node + 1] + tree[2 * node + 2];
        }

        public int Query(int left, int right)
        {
            return QueryTree(0, 0, n - 1, left, right);
        }

        private int QueryTree(int node, int start, int end, int left, int right)
        {
            if (left > end || right < start)
                return 0;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) / 2;
            int leftSum = QueryTree(2 * node + 1, start, mid, left, right);
            int rightSum = QueryTree(2 * node + 2, mid + 1, end, left, right);

            return leftSum + rightSum;
        }

        public void PrintTree()
        {
            Console.WriteLine("Segment Tree Structure:");
            PrintTreeHelper(0, 0, n - 1, 0);
        }

        private void PrintTreeHelper(int node, int start, int end, int depth)
        {
            // Print indentation based on depth
            Console.Write(new string(' ', depth * 4));

            // Print node information
            Console.WriteLine($"Node {node} ({start}-{end}): {tree[node]}");

            if (start != end)
            {
                int mid = (start + end) / 2;
                PrintTreeHelper(2 * node + 1, start, mid, depth + 1);
                PrintTreeHelper(2 * node + 2, mid + 1, end, depth + 1);
            }
        }
    }
}
