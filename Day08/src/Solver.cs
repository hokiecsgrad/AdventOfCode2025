using AdventOfCode.Common;

namespace AdventOfCode.Day08;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        long product = 0;

        // Parse strings into points
        List<(int x, int y, int z)> junctionBoxes = CreateJunctionBoxPositions(data);

        // Calculate distances between all points
        Dictionary<(int source, int dest), double> distances = CalcDistancesBetweenAllJunctionBoxes(junctionBoxes);

        // Get the 1000 shortest distances
        List<KeyValuePair<(int source, int dest), double>> shortestDistances = distances.OrderBy(key => key.Value).Take(10).ToList();

        // Create circuits
        List<HashSet<int>> circuits = new();
        foreach (var pair in shortestDistances)
        {
            int source = pair.Key.source;
            int dest = pair.Key.dest;

            (int source, int dest) foundInCircuit = (-1, -1);
            foundInCircuit = SearchCircuitsForSourceAndDest(circuits, source, dest);

            MergeCircuits(circuits, source, dest, foundInCircuit, junctionBoxes, ref product);
        }

        // Product is the multiplication of the number of junction boxes in each unique circuit
        circuits = circuits.OrderByDescending(key => key.Count).Take(3).ToList();
        product = circuits.Aggregate(1, (acc, circuit) => acc * circuit.Count);

        return product.ToString();
    }

    public string SolvePart2(string[] data)
    {
        long product = 0;

        // Parse strings into points
        List<(int x, int y, int z)> junctionBoxes = CreateJunctionBoxPositions(data);

        // Calculate distances between all points
        Dictionary<(int source, int dest), double> distances = CalcDistancesBetweenAllJunctionBoxes(junctionBoxes);

        // Order all the distances from shortest to longest
        List<KeyValuePair<(int source, int dest), double>> shortestDistances = distances.OrderBy(key => key.Value).ToList();

        // Create circuits
        List<HashSet<int>> circuits = new();
        foreach (var pair in shortestDistances)
        {
            int source = pair.Key.source;
            int dest = pair.Key.dest;

            (int source, int dest) foundInCircuit = (-1, -1);
            foundInCircuit = SearchCircuitsForSourceAndDest(circuits, source, dest);

            MergeCircuits(circuits, source, dest, foundInCircuit, junctionBoxes, ref product);
        }

        return product.ToString();
    }

    private List<(int x, int y, int z)> CreateJunctionBoxPositions(string[] data)
    {
        List<(int x, int y, int z)> junctionBoxes = new();
        foreach (string line in data)
        {
            string[] parts = line.Split(',', StringSplitOptions.TrimEntries);
            junctionBoxes.Add((
                int.Parse(parts[0]),
                int.Parse(parts[1]),
                int.Parse(parts[2])
                ));
        }

        return junctionBoxes;
    }

    private Dictionary<(int source, int dest), double> CalcDistancesBetweenAllJunctionBoxes(List<(int x, int y, int z)> junctionBoxes)
    {
        Dictionary<(int source, int dest), double> distances = new();
        for (int i = 0; i < junctionBoxes.Count; i++)
        {
            for (int j = 0; j < junctionBoxes.Count; j++)
            {
                // don't create a circuit to itself
                if (i == j) continue;
                // don't create a circuit that already exists
                if (distances.ContainsKey((i, j)) || distances.ContainsKey((j, i))) continue;

                double dist = Math.Sqrt( 
                                    Math.Pow(junctionBoxes[i].x - junctionBoxes[j].x, 2) +
                                    Math.Pow(junctionBoxes[i].y - junctionBoxes[j].y, 2) +
                                    Math.Pow(junctionBoxes[i].z - junctionBoxes[j].z, 2)
                            );
                
                distances[(i, j)] = dist;
            }
        }

        return distances;
    }

    private (int source, int dest) SearchCircuitsForSourceAndDest(List<HashSet<int>> circuits, int source, int dest)
    {
        (int source, int dest) foundInCircuit = (-1, -1);
        for (int i = 0; i < circuits.Count; i++)
        {
            if (circuits[i].Contains(source))
            { 
                foundInCircuit.source = i; 
            }
            if (circuits[i].Contains(dest))
            {
                foundInCircuit.dest = i;
            }
        }

        return foundInCircuit;
    }

    private void MergeCircuits(List<HashSet<int>> circuits, int source, int dest, (int source, int dest) foundInCircuit, List<(int x, int y, int z)> junctionBoxes, ref long product)
    {
        bool sourceAndDestInSameCircuit = foundInCircuit.source != -1 && foundInCircuit.dest != -1 && foundInCircuit.source == foundInCircuit.dest;
        if (!sourceAndDestInSameCircuit)
        {
            if (foundInCircuit.source == -1 && foundInCircuit.dest == -1)
            {
                // Create new circuit
                circuits.Add(new HashSet<int> { source, dest });
            }
            else if (foundInCircuit.source != -1 && foundInCircuit.dest == -1)
            {
                circuits[foundInCircuit.source].Add(dest);
            }
            else if (foundInCircuit.source == -1 && foundInCircuit.dest != -1)
            {
                circuits[foundInCircuit.dest].Add(source);
            }
            else if (foundInCircuit.source != -1 && foundInCircuit.dest != -1 && foundInCircuit.source != foundInCircuit.dest)
            {
                // Merge circuits
                circuits[foundInCircuit.source].UnionWith(circuits[foundInCircuit.dest]);
                circuits.RemoveAt(foundInCircuit.dest);
            }

            if (circuits.Count == 1 && circuits[0].Count == junctionBoxes.Count) 
                product = junctionBoxes[source].x * junctionBoxes[dest].x;
        }
    }
}