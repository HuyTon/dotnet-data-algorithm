public class Node(int data)
{
    public int Data { get; set; } = data;
    public Node? Next { get; set; } = null;
}

public class LinkedList
{
    private Node? head = null;

    public void Insert(int data)
    {
        if (head == null)
        {
            head = new Node(data);
        }
        else
        {
            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = new Node(data);
        }
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("null");
            return;
        }

        Node? current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }

        Console.WriteLine("null"); // Write the tail of linked list is always null
    }

    public Node? FindMiddleElementOfList()
    {
        if (head == null) return null;

        Node slow = head;
        Node fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }
}

public class StackAlgorithm
{
    public void Basic()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine("Popped element: " + stack.Pop());

        Console.WriteLine("Top element: " + stack.Peek());
    }
}

public class QueueAlgorithm
{
    public void Basic()
    {
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Console.WriteLine("Dequeued element: " + queue.Dequeue());

        Console.WriteLine("Front element: " + queue.Peek());
    }
}

public class HashMapAlgorithm
{
    public void Basic()
    {
        Dictionary<string, int> hashMap = new Dictionary<string, int>();

        hashMap.Add("apple", 10);
        hashMap.Add("banana", 20);
        hashMap.Add("orange", 30);

        Console.WriteLine("Value of apple: " + hashMap["apple"]);
        Console.WriteLine("Value of banana: " + hashMap["banana"]);
        Console.WriteLine("Value of orange: " + hashMap["orange"]);

        if (hashMap.ContainsKey("apple"))
        {
            Console.WriteLine("'apple' exists in the HashMap");
        }

        foreach (KeyValuePair<string, int> kvp in hashMap)
        {
            Console.WriteLine($"Key: ${kvp.Key}, Value: ${kvp.Value}");
        }
    }
}