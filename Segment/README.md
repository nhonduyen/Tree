 A segment tree is a powerful data structure used for solving range query problems efficiently. 
 It's particularly useful for operations like range sum queries, range minimum queries,
 and similar problems where you need to perform operations on intervals of an array.

 Array [2, 1, 5, 3, 4] can build the tree like this:

          [15]
        /      \
     [8]        [7]
    /  \       /  \
  [3]  [5]   [3]  [4]
 /  \   |
[2] [1] [5]

