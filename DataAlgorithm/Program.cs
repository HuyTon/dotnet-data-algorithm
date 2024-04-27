using TreeTriversal;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Data Processing Algorithms and Transaction Management Repository!");
        Console.WriteLine("This repository provides a comprehensive toolkit for processing and managing transactions efficiently.");
        Console.WriteLine("Feel free to explore the features, components, and usage instructions in the README.md file.");

        Console.WriteLine("\n\r");

        Console.WriteLine("*** Transaction Comparision ***");
        Console.WriteLine("We have two transactions sets, one is data source and one is destination. Compare two sets.");
        Console.WriteLine("Output: what's transaction only in data source and what is only in destination and what is in both of them!");
        Console.WriteLine("\n\r");

        // Read transactions data
        TransactionData data = new();
        List<Transaction> dataSourceTransactions = data.ReadTransactionFromDataSource();
        List<Transaction> destinationTransactions = data.ReadTransactionFromDataDestination();

        // Compare transactions
        var onlyInSourceTransactions = dataSourceTransactions.Except(destinationTransactions, new TransactionEqualityComparer());
        var onlyInDestinationTransactions = destinationTransactions.Except(dataSourceTransactions, new TransactionEqualityComparer());
        var inBothTransactions = dataSourceTransactions.Intersect(destinationTransactions, new TransactionEqualityComparer());

        Console.WriteLine("Transaction only in data source:");
        foreach (var transaction in onlyInSourceTransactions)
        {
            Console.WriteLine(transaction);
        }
        // Date: 4/1/2024 12:00:00 AM, Quantity: 10, Amount: 100

        Console.WriteLine("\nTransaction only in destination:");
        foreach (var transaction in onlyInDestinationTransactions)
        {
            Console.WriteLine(transaction);
        }
        // Date: 4/4/2024 12:00:00 AM, Quantity: 40, Amount: 400 

        Console.WriteLine("\nTransaction in both of transactions:");
        foreach (var transaction in inBothTransactions)
        {
            Console.WriteLine(transaction);
        }
        // Date: 4/2/2024 12:00:00 AM, Quantity: 20, Amount: 200 
        // Date: 4/3/2024 12:00:00 AM, Quantity: 30, Amount: 300 

        Console.WriteLine("\n\r");
        Console.WriteLine("*** LinkedList ***");

        LinkedList linkedList = new();
        linkedList.Insert(1);
        linkedList.Insert(2);
        linkedList.Insert(3);
        linkedList.Insert(4);
        linkedList.Insert(5);

        linkedList.Display(); // 1 -> 2 -> 3 -> 4 -> 5 -> null

        Console.WriteLine("\n\r");
        Console.WriteLine("*** Searching on a Binary Tree ***");

        BinaryTree binaryTree = new();
        binaryTree.FindPath('d'); // [a, b, d]
        binaryTree.FindPath('c'); // [a, b, c]
        binaryTree.FindPath('f'); // [a, e, f]
        binaryTree.FindPath('g'); // [a, e, g]

        Console.WriteLine("\n\r");
        Console.WriteLine("*** Tree Traversal ***");

        TriversalBinaryTree triversalBinaryTree = new();
        triversalBinaryTree.Insert(5);
        triversalBinaryTree.Insert(3);
        triversalBinaryTree.Insert(1);
        triversalBinaryTree.Insert(7);
        triversalBinaryTree.Insert(9);
        triversalBinaryTree.Insert(8);

        triversalBinaryTree.TraverseTree(); // 1 3 5 7 8 9

        Console.WriteLine("\n\r");
        Console.WriteLine("*** Serialize Binary Tree ***");

        TreeNode<char> root = new TreeNode<char>('a');
        root.Left = new TreeNode<char>('b');
        root.Right = new TreeNode<char>('c');
        root.Left.Left = new TreeNode<char>('d');
        root.Left.Right = new TreeNode<char>('e');
        root.Right.Right = new TreeNode<char>('f');

        BinaryTreeSerializer<char> serializer = new BinaryTreeSerializer<char>();
        string serializedTree = serializer.Serialize(root);
        Console.WriteLine("Serialized Tree: " + serializedTree);

        TreeNode<char>? deserializedRoot = serializer.Deserialize(serializedTree);
        Console.WriteLine("Deserialized Tree:");
        root.PrintTree(deserializedRoot);

    }
}