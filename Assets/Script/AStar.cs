using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar {

    private const int MOVE_COST = 2;
    private const int DIAGONAL_COST = 3;
    private const int SEMIDIAGONAL_COST = 4;

    public static Path FindPath(Node start, Node goal) {

        Dictionary<Node, bool> closedSet = new Dictionary<Node, bool>();
        Dictionary<Node, bool> openSet = new Dictionary<Node, bool>();

        //cost of start to this key node
        Dictionary<Node, int> gScore = new Dictionary<Node, int>();
        //cost of start to goal, passing through key node
        Dictionary<Node, int> fScore = new Dictionary<Node, int>();

        Dictionary<Node, Node> nodeLinks = new Dictionary<Node, Node>();

        int loopCount = 0;

        //if (graph == null) return null;

        bool endUnreachable = true;

        openSet[start] = true;
        gScore[start] = 0;
        fScore[start] = Heuristic(start, goal);

        while (openSet.Count > 0) {
            var current = nextBest(openSet, fScore);
            if (current.Equals(goal)) {
                return new Path(Reconstruct(current, nodeLinks));
            } else if (loopCount > 1000) {
                int minScore = int.MaxValue;
                Node point = current;
                foreach (KeyValuePair<Node, int> kvp in fScore) {
                    if (kvp.Value < minScore) {
                        minScore = kvp.Value;
                        point = kvp.Key;
                    }
                }
                return new Path(Reconstruct(point, nodeLinks), !endUnreachable);
            }

            loopCount++;

            openSet.Remove(current);
            closedSet[current] = true;

            foreach (var neighbor in current.neighbours) {
                if (closedSet.ContainsKey(neighbor))
                    continue;

                var projectedG = getGScore(current, gScore) + MovementPrice(current, neighbor);

                if (!openSet.ContainsKey(neighbor))
                    openSet[neighbor] = true;
                else if (projectedG >= getGScore(neighbor, gScore))
                    continue;

                //record it
                nodeLinks[neighbor] = current;
                gScore[neighbor] = projectedG;
                fScore[neighbor] = projectedG + Heuristic(neighbor, goal);

            }
        }


        return Path.EmptyPath();
    }


    private static int MovementPrice(Node center, Node neighbor) {
        return Mathf.FloorToInt(Vector2.Distance(center.position, neighbor.position));
    }

    private static int Heuristic(Node start, Node goal) {
        var dx = Mathf.Abs(goal.position.x - start.position.x);
        var dy = Mathf.Abs(goal.position.y - start.position.y);
        //var diff = Mathf.Abs(dx - dy);
        var shared = Mathf.Min(dx, dy);
        return Mathf.FloorToInt(shared * MOVE_COST);
    }

    private static int getGScore(Node pt, Dictionary<Node, int> gScore) {
        int score = int.MaxValue;
        gScore.TryGetValue(pt, out score);
        return score;
    }


    private static int getFScore(Node pt, Dictionary<Node, int> fScore) {
        int score = int.MaxValue;
        fScore.TryGetValue(pt, out score);
        return score;
    }

    private static List<Node> Reconstruct(Node current, Dictionary<Node, Node> nodeLinks) {
        List<Node> path = new List<Node>();
        while (nodeLinks.ContainsKey(current)) {
            path.Add(current);
            current = nodeLinks[current];
        }

        path.Reverse();
        return path;
    }

    private static Node nextBest(Dictionary<Node, bool> openSet, Dictionary<Node, int> fScore) {
        int best = int.MaxValue;
        Node bestPt = null;
        foreach (var node in openSet.Keys) {
            var score = getFScore(node, fScore);
            if (score < best) {
                bestPt = node;
                best = score;
            }
        }


        return bestPt;
    }

}
