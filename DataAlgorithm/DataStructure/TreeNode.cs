public class TreeNode<T>
{
    public T Data { get; }
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
}
