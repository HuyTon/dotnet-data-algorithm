/*
Define a binary tree and then write a function find that searches for a specified value in this tree.
Example, the tree structure is as follows:

 a
 / \
 b    e
 / \  / \
 c  d f  g
*/

class BinaryTree
{
    public TreeNode<char> root;

    public BinaryTree()
    {
        root = new TreeNode<char>('a')
        {
            Left = new TreeNode<char>('b'),
            Right = new TreeNode<char>('e'),
        };
        root.Left.Left = new TreeNode<char>('c');
        root.Left.Right = new TreeNode<char>('d');
        root.Right.Left = new TreeNode<char>('f');
        root.Right.Right = new TreeNode<char>('g');
    }

    public bool Find(char value)
    {
        return FindRecursive(root, value);
    }

    public bool FindPath(char value)
    {
        // Expected output:
        // findPath(root, d) -> [a, b, d] 
        // findPath(root, c) -> [a, b, c]
        // findPath(root, f) -> [a, e, f]

        List<char> paths = [];

        bool found = FindPathRecursive(root, value, paths);

        paths.Reverse();

        if (found) DisplayFoundPath(paths);

        return found;
    }

    private bool FindRecursive(TreeNode<char>? node, char value)
    {
        if (node == null) return false;

        if (node.Data == value) return true;

        return FindRecursive(node.Left, value) || FindRecursive(node.Right, value);
    }

    private bool FindPathRecursive(TreeNode<char>? node, char value, List<char> paths)
    {
        if (node == null) return false;

        if (node.Data == value)
        {
            paths.Add(node.Data);

            return true;
        }

        var left = FindPathRecursive(node.Left, value, paths);
        var right = FindPathRecursive(node.Right, value, paths);

        if (left || right)
        {
            paths.Add(node.Data);
        }

        return left || right;
    }

    private void DisplayFoundPath(List<char> paths)
    {
        if (paths != null && paths.Count > 0)
        {
            string result = "[" + string.Join(", ", paths) + "]";

            Console.WriteLine(result);
        }
    }

}
