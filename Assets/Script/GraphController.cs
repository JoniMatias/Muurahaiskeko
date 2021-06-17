using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Roy_T.AStar.Graphs;


public class GraphController {

    public static HashSet<Node> nodes = new HashSet<Node>();

    private static Roy_T.AStar.Graphs.Node _initialNode = null;

    public static Roy_T.AStar.Graphs.Node initialNode {
        get {
            if (_initialNode == null) {
                _initialNode = new Roy_T.AStar.Graphs.Node(new Roy_T.AStar.Primitives.Position(0,0));
            }
            return _initialNode;
        }
    }


    public static void ConnectNodes(Node start, Node end) {
        start.Connect(end, Roy_T.AStar.Primitives.Velocity.FromMetersPerSecond(2));
        end.Connect(start, Roy_T.AStar.Primitives.Velocity.FromMetersPerSecond(2));

        nodes.Add(end);
    }

    public static Node ClosestNodeToPosition(Vector2 position) {
        float closestDistance = float.MaxValue;
        Node closestNode = null;
        foreach (Node node in nodes) {
            float distance = Vector2.Distance(node.Position, position);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestNode = node;
            }
        }
        return closestNode;
    }

    public static Node BuildNodesToPosition(Vector2 target, Node startNode) {
        float nodeDistance = 0.8f;

        Vector2 nodePos;

        if (Vector2.Distance(startNode.Position, target) > nodeDistance) {
            nodePos = target;
        } else {
            Vector2 direction = (target - startNode.Position).normalized;
            direction *= nodeDistance;

            nodePos = direction + new Vector2(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
        }


        Node newNode = new Node(nodePos);

        ConnectNodes(newNode, startNode);
        ConnectNodes(startNode, newNode);

        if (Vector2.Distance(newNode.Position, target) < 0.2f) {
            return newNode;
        } else {
            return BuildNodesToPosition(target, newNode);
        }
    }

}
