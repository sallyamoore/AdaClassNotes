# Trees
- common topic of interview questions

## Terms:
### Nodes - branch points
### Root - top node
### Parent - the node that points at this node
### Siblings - Nodes at same level as this node
### Descendent - any node further down the same branch as the current node
### Ancestor - any node further up the same branch as the current node
### Leaf - node with no children
### Edge - connection between two nodes
### Path - sequence of nodes and edges followed down the tree
### Level - 1 + number of edges to the bottom. (Or number of nodes deep). Refers to whole tree.
### Height - number of edges of longest path between root and a leaf
### Depth - how far down this node is from root

## Linked list vs tree

Linked list nodes:
- contain Data
- contain a pointer (single - to next, double - to next & prev, circular - end to front)
- traversed linearly

Tree nodes:
- contain data
- contain a pointer
    - binary tree - left/right
    - other tree - any number of children
- each node only knows about the node(s) beneath it
- traversed recursively, log n (root to leaf)
- siblings don't know about each other

Linked list front/head node - tree equivalent is root node.

## Traversing Trees
when printed, trees are printed all in one line.
Start to left of root node, trace around the tree until you reach the root again.
To show structure:
- in-order traversal - Each node is printed when you hit between where left and right child would be. In other words, print node when you're in the middle of all downward paths on tree. (in her visual: abcdefghi) Go left, print, go right.
- pre-order traversal - similar, but you print when you hit the left side of each node.
(in her visual: fbadcegih) Print, go left, go right.
- post-order traversal - similar, but you print when you hit the right side of each node. (in her visual: acedbhigf) Go left, go right, print.

pseudocode example:
def pre_print_tree(tree_node)
  puts tree_node.data
  pre_print_tree(tree_node.left_child)
  pre_print_tree(tree_node.right_child)
end

def in_print_tree(tree_node)
  in_print_tree(tree_node.left_child)
  puts tree_node.data
  in_print_tree(tree_node.right_child)
end

def post_print_tree(tree_node)
  post_print_tree(tree_node.left_child)
  post_print_tree(tree_node.right_child)
  puts tree_node.data
end

## Special Trees
- Binary - at most, two children per node.
- binary search tree (BST) - at most, two children per node. Data goes into the tree first at root; if smaller, goes to left; if bigger, goes to right; recurse.

  [89, 3, 12, 56, 2, 10, 99, 100, 1] =>
        89
       /  \
      3   99
     / \    \
    2   12  100
   / \    \
  1   10   56
- binary expression - 4 * 3 + 8 / 6 =>
                +
             /     \
            *    ( / )
           / \    / \
          4   3  8   6

        in pre-order:  => + * 4 3 / 8 6  
    in some langs you _have_ to write an equation this way!
- balanced - cannot have an edge two longer than another. Make as symmetrical as possible.
Maintains efficiency of working down tree.
- full binary - all nodes up to and including last level have two children
        n
       / \
      n   n
     / \  / \
    n   nn   n
- complete binary - can lose any nodes from bottom level starting from right with now gaps.

## Depth first versus breadth first

        a
       / \
      b   e
     / \  / \
    c   df   g

### depth
Go as deep as you can (see traversion types above) first, then up.
### breadth
Do all on same level, then move to next level: a b e c d f g 
