// See https://aka.ms/new-console-template for more information
using BST;

Console.WriteLine("Binary search tree");

int[] arr = { 50, 30, 20, 40, 70, 60, 80 };

BinarySearchTree bst = new BinarySearchTree();

foreach (int i in arr)
{
    bst.Insert(i);
}


Console.WriteLine("InOrder traversal of the BST:");
bst.InOrderTraversal();

Console.WriteLine("Search for 40: " + bst.Search(40));
Console.WriteLine("Search for 100: " + bst.Search(100));

Console.WriteLine("Deleting 20");
bst.Delete(20);
Console.WriteLine("InOrder traversal after deletion:");
bst.InOrderTraversal();
