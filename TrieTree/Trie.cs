namespace TrieTree
{
    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        // Insert a word into the trie
        public void Insert(string word)
        {
            var current = _root;
            foreach (var ch in word)
            {
                if (!current.Children.ContainsKey(ch))
                {
                    current.Children[ch] = new TrieNode();
                }
                current = current.Children[ch];
            }
            current.IsEndOfWord = true;
        }

        // Search for a word in the trie
        public bool Search(string word)
        {
            var current = _root;
            foreach (var ch in word)
            {
                if (!current.Children.ContainsKey(ch))
                {
                    return false;
                }
                current = current.Children[ch];
            }
            return current.IsEndOfWord;
        }

        // Delete a word from the trie
        public bool Delete(string word)
        {
            return Delete(_root, word, 0);
        }

        private bool Delete(TrieNode current, string word, int index)
        {
            if (index == word.Length)
            {
                if (!current.IsEndOfWord)
                {
                    return false;
                }
                current.IsEndOfWord = false;
                return current.Children.Count == 0;
            }

            var ch = word[index];
            if (!current.Children.ContainsKey(ch))
            {
                return false;
            }

            var node = current.Children[ch];
            var shouldDeleteCurrentNode = Delete(node, word, index + 1);

            if (shouldDeleteCurrentNode)
            {
                current.Children.Remove(ch);
                return current.Children.Count == 0;
            }

            return false;
        }

        // StartsWith to check if there is any word with the given prefix
        public bool StartsWith(string prefix)
        {
            var current = _root;
            foreach (var ch in prefix)
            {
                if (!current.Children.ContainsKey(ch))
                {
                    return false;
                }
                current = current.Children[ch];
            }
            return true;
        }
    }

}
