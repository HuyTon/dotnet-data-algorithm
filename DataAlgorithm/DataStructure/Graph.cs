using System;
using System.Collections.Generic;
using System.Linq;

public class Graph
{
    private Dictionary<int, Dictionary<int, int>> _adjacencyList = new Dictionary<int, Dictionary<int, int>>();

    public void AddEdge(int source, int destination, int weight)
    {
        if (!_adjacencyList.ContainsKey(source))
        {
            _adjacencyList[source] = new Dictionary<int, int>();
        }

        _adjacencyList[source][destination] = weight;
    }

    /// <summary>
    /// Dijkstra's algorithm is a popular algorithm used to find the shortest paths between nodes in a graph, 
    /// particularly in weighted graphs with non-negative edge weights.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public Dictionary<int, int> Dijkstra(int source)
    {
        var distances = new Dictionary<int, int>();
        var priorityQueue = new SortedSet<int>(Comparer<int>.Create((x, y) => distances[x] != distances[y] ? distances[x].CompareTo(distances[y]) : x.CompareTo(y)));

        foreach (var vertex in _adjacencyList.Keys)
        {
            distances[vertex] = int.MaxValue;
            priorityQueue.Add(vertex);
        }

        distances[source] = 0;

        while (priorityQueue.Any())
        {
            var currentVertex = priorityQueue.Min;
            priorityQueue.Remove(currentVertex);

            foreach (var neighbor in _adjacencyList[currentVertex])
            {
                var alternativeDistance = distances[currentVertex] + neighbor.Value;
                if (alternativeDistance < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = alternativeDistance;
                    priorityQueue.Remove(neighbor.Key); // Remove and re-add to update priority
                    priorityQueue.Add(neighbor.Key);
                }
            }
        }

        return distances;
    }

    public void TestDijkstra()
    {
        Graph graph = new Graph();
        graph.AddEdge(0, 1, 4);
        graph.AddEdge(0, 7, 8);
        graph.AddEdge(1, 2, 8);
        graph.AddEdge(1, 7, 11);
        graph.AddEdge(2, 3, 7);
        graph.AddEdge(2, 8, 2);
        graph.AddEdge(2, 5, 4);
        graph.AddEdge(3, 4, 9);
        graph.AddEdge(3, 5, 14);
        graph.AddEdge(4, 5, 10);
        graph.AddEdge(5, 6, 2);
        graph.AddEdge(6, 7, 1);
        graph.AddEdge(6, 8, 6);
        graph.AddEdge(7, 8, 7);

        Dictionary<int, int> distances = graph.Dijkstra(0);

        Console.WriteLine("Vertex   Distance from Source");
        foreach (var vertex in distances)
        {
            Console.WriteLine($"{vertex.Key}\t\t{vertex.Value}");
        }
    }
}