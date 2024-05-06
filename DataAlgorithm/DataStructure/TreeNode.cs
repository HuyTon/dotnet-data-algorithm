public class TreeNode<T>
{
    public T? Data { get; }
    public TreeNode<T>? Left { get; set; }
    public TreeNode<T>? Right { get; set; }

    public TreeNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }

    public void PrintTree(TreeNode<T>? root)
    {
        if (root == null)
            return;

        Console.WriteLine(root.Data);
        PrintTree(root.Left);
        PrintTree(root.Right);
    }

    public bool IsSameTree(TreeNode<T>? t1, TreeNode<T>? t2)
    {
        if (t1 == null && t2 == null) return true;

        if ((t1 == null && t2 != null) || (t1 != null && t2 == null))
        {
            return false;
        }

        // if (!t1.Data.Equals(t2.Data)) return false;
        if (!EqualityComparer<T>.Default.Equals(t1.Data, t2.Data)) return false;

        return IsSameTree(t1.Left, t2.Left) && IsSameTree(t1.Right, t2.Right);
    }

    public static TreeNode<T>? FindCommonAncestor(TreeNode<T>? root, TreeNode<T> node1, TreeNode<T> node2)
    {
        if (root == null || root == node1 || root == node2)
        {
            return root;
        }

        TreeNode<T>? leftAncestor = FindCommonAncestor(root.Left, node1, node2);
        TreeNode<T>? rightAncestor = FindCommonAncestor(root.Right, node1, node2);

        if (leftAncestor != null && rightAncestor != null)
        {
            return root; // Current node is the common ancestor
        }

        return leftAncestor ?? rightAncestor; // Return the non-null ancestor
    }
}
