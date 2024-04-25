
namespace TreeTriversal
{
    public class TriversalBinaryTree
    {
        private TreeNode<int>? root;

        public TriversalBinaryTree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            root = InsertRecursive(root, data);
        }

        private TreeNode<int> InsertRecursive(TreeNode<int>? root, int data)
        {
            if (root == null)
            {
                root = new TreeNode<int>(data);
                return root;
            }

            if (data < root.Data)
            {
                root.Left = InsertRecursive(root.Left, data);
            }

            if (data > root.Data)
            {
                root.Right = InsertRecursive(root.Right, data);
            }

            return root;
        }

        public void TraverseTree()
        {
            TraverseTreeRecursive(root);
        }

        private void TraverseTreeRecursive(TreeNode<int>? root)
        {
            if (root != null)
            {
                TraverseTreeRecursive(root.Left);

                Console.Write(root.Data + " ");

                TraverseTreeRecursive(root.Right);
            }
        }
    }
}
