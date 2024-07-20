// See https://aka.ms/new-console-template for more information
using RedBlack;

Console.WriteLine("Red black tree");
RedBlackTree rbt = new RedBlackTree();
rbt.Insert(10);
rbt.Insert(20);
rbt.Insert(30);
rbt.Insert(15);
rbt.Insert(25);

Console.WriteLine("In-order traversal of Red-Black Tree:");
rbt.InOrderTraversal();