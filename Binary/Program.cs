// See https://aka.ms/new-console-template for more information
using Binary;

Console.WriteLine("Binary tree!");

int[] arr = { 5, 3, 7, 1, 9 };

BinaryTree tree = new BinaryTree();

foreach (int i in arr)
{
    tree.Insert(i);
}

Console.WriteLine("In-order traversal:");
tree.InOrderTraversal();
Console.WriteLine();

Console.WriteLine("Tree contains 7: " + tree.Contains(7));
Console.WriteLine("Tree contains 10: " + tree.Contains(10));