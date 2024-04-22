using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

class Transaction
{
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public int Amount { get; set; }

    public override string ToString()
    {
        return $"Date: {Date}, Quantity: {Quantity}, Amount: {Amount} ";
    }
}

class TransactionEqualityComparer : IEqualityComparer<Transaction>
{
    public bool Equals(Transaction? x, Transaction? y)
    {
        if (x == null || y == null) return false;

        return x.Date == y.Date && x.Quantity == y.Quantity && x.Amount == y.Amount;
    }

    public int GetHashCode([DisallowNull] Transaction obj)
    {
        return obj.Date.GetHashCode() ^ obj.Quantity.GetHashCode() ^ obj.Amount.GetHashCode();
    }
}

class TransactionData
{
    public List<Transaction> ReadTransactionFromDataSource()
    {
        return
        [
            new Transaction() { Date = new DateTime(2024, 4, 1), Quantity = 10, Amount = 100 },
            new Transaction() { Date = new DateTime(2024, 4, 2), Quantity = 20, Amount = 200 },
            new Transaction() { Date = new DateTime(2024, 4, 3), Quantity = 30, Amount = 300 }
        ];
    }

    public List<Transaction> ReadTransactionFromDataDestination()
    {
        return
        [
            new Transaction() { Date = new DateTime(2024, 4, 2), Quantity = 20, Amount = 200 },
            new Transaction() { Date = new DateTime(2024, 4, 3), Quantity = 30, Amount = 300 },
            new Transaction() { Date = new DateTime(2024, 4, 4), Quantity = 40, Amount = 400 }
        ];
    }
}