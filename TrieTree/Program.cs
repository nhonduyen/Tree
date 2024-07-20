// See https://aka.ms/new-console-template for more information
using TrieTree;

Console.WriteLine("Trie");

var trie = new Trie();

var strings = new List<string>()
{
    "apple",
    "app",
    "application"
};

Console.WriteLine(string.Join(", ", strings));

foreach (var s in strings)
{
    trie.Insert(s);
}


Console.WriteLine($"Search for apple: {trie.Search("apple")}"); // True
Console.WriteLine($"Search for app: {trie.Search("app")}");   // True
Console.WriteLine($"Search for appl: {trie.Search("appl")}");  // False
Console.WriteLine($"Start with app: {trie.StartsWith("app")}"); // True

trie.Delete("app");
Console.WriteLine("Delete app");
Console.WriteLine($"Search for app: {trie.Search("app")}");  // False
Console.WriteLine($"Search for apple: {trie.Search("apple")}"); // True
