// See https://aka.ms/new-console-template for more information
using Segment;

Console.WriteLine("Segment tree");

int[] arr = { 1, 3, 5, 7, 9, 11 };
SegmentTree segTree = new SegmentTree(arr);

Console.WriteLine(string.Join(" ", arr));

Console.WriteLine("Sum of range 1 - 3");
Console.WriteLine(segTree.Query(1, 3)); // Output: 15 (3 + 5 + 7)

segTree.PrintTree();

Console.WriteLine("Update 1 to 10");
segTree.Update(1, 10);

Console.WriteLine(string.Join(" ", arr));

Console.WriteLine("Sum of range 1 - 3");
Console.WriteLine(segTree.Query(1, 3)); // Output: 22 (10 + 5 + 7)

segTree.PrintTree();

