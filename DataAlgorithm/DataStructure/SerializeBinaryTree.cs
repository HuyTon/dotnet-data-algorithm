using System.Text;

public class BinaryTreeSerializer<T>
{
    public string Serialize(TreeNode<T>? root)
    {
        StringBuilder sb = new StringBuilder();
        SerializeHelper(root, sb);
        return sb.ToString();
    }

    private void SerializeHelper(TreeNode<T>? node, StringBuilder sb)
    {
        if (node == null)
        {
            sb.Append("null,");
            return;
        }

        sb.Append(node.Data.ToString() + ",");
        SerializeHelper(node.Left, sb);
        SerializeHelper(node.Right, sb);
    }

    public TreeNode<T>? Deserialize(string data)
    {
        string[] dataArray = data.Split(',');
        int index = 0;
        return DeserializeHelper(dataArray, ref index);
    }

    private TreeNode<T>? DeserializeHelper(string[] dataArray, ref int index)
    {
        if (index >= dataArray.Length || dataArray[index] == "null")
        {
            index++;
            return null;
        }

        TreeNode<T> node = new TreeNode<T>((T)Convert.ChangeType(dataArray[index], typeof(T)));
        index++;
        node.Left = DeserializeHelper(dataArray, ref index);
        node.Right = DeserializeHelper(dataArray, ref index);
        return node;
    }
}