// See https://aka.ms/new-console-template for more information
using AVL;

Console.WriteLine("AVL");

AVLTree avl = new AVLTree();

int[] arr = { 50, 30, 20, 40, 70, 60, 80 };

foreach (int i in arr)
{
    avl.Insert(i);
}


Console.WriteLine("InOrder traversal of the AVL tree:");
avl.InOrderTraversal();

Console.WriteLine("Search for 30: " + avl.Search(30));
Console.WriteLine("Search for 60: " + avl.Search(60));
