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

        Console.WriteLine("\nTransaction only in destination:");
        foreach (var transaction in onlyInDestinationTransactions)
        {
            Console.WriteLine(transaction);
        }

        Console.WriteLine("\nTransaction in both of transactions:");
        foreach (var transaction in inBothTransactions)
        {
            Console.WriteLine(transaction);
        }
    }
}