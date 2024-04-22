/*
Define a binary tree and then write a function find that searches for a specified value in this tree.
Example, the tree structure is as follows:

 a
 / \
 b    e
 / \  / \
 c  d f  g
*/
using System.Security.Cryptography.X509Certificates;

public class Node(char data)
{
    public char Data { get; } = data;
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}

class BinaryTree
{
    public Node Root { get; private set; }
    public BinaryTree()
    {
        Root = new Node('a')
        {
            Left = new Node('b'),
            Right = new Node('e'),
        };
        Root.Left.Left = new Node('c');
        Root.Left.Right = new Node('d');
        Root.Right.Left = new Node('f');
        Root.Right.Right = new Node('g');
    }

    public bool Find(char value)
    {
        return FindRecursive(Root, value);
    }

    private bool FindRecursive(Node? node, char value)
    {
        if (node == null) return false;

        if (node.Data == value) return true;

        return FindRecursive(node.Left, value) || FindRecursive(node.Right, value);
    }
}
