using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Roy_T.AStar.Graphs;


public class GraphController {

    public static HashSet<Node> nodes = new HashSet<Node>();

    private static Roy_T.AStar.Graphs.Node _initialNode = null;

    private static List<Node> _foodNodes = null;

    public static Roy_T.AStar.Graphs.Node initialNode {
        get {
            if (_initialNode == null) {
                _initialNode = new Roy_T.AStar.Graphs.Node(new Roy_T.AStar.Primitives.Position(0,0));
                nodes.Add(_initialNode);
            }
            return _initialNode;
        }
    }

    public static List<Node> foodNodes {
        get {
            if (_foodNodes == null) {
                _foodNodes = new List<Node>();
                Node n1 = new Node(new Vector2(-11, -3));
                Node n2 = new Node(new Vector2(-11, 0));
                Node n3 = new Node(new Vector2(-11, 3));
                Node n4 = new Node(new Vector2(11, -3));
                Node n5 = new Node(new Vector2(11, 0));
                Node n6 = new Node(new Vector2(11, 3));

                _foodNodes.Add(n1);
                _foodNodes.Add(n2);
                _foodNodes.Add(n3);
                _foodNodes.Add(n4);
                _foodNodes.Add(n5);
                _foodNodes.Add(n6);
            }
            return _foodNodes;
        }
    }


    public static void ConnectNodes(Node start, Node end) {
        start.Connect(end, Roy_T.AStar.Primitives.Velocity.FromMetersPerSecond(2));
        end.Connect(start, Roy_T.AStar.Primitives.Velocity.FromMetersPerSecond(2));

        nodes.Add(start);
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

    public static Node BuildNodesToNode(Node target, Node startNode) {
        float nodeDistance = 0.8f;

        Vector2 nodePos;

        Debug.Log("BuildNodesToNode " + target + " >> " + startNode);
        if (Vector2.Distance(startNode.Position, target.Position) > nodeDistance) {
            ConnectNodes(target, startNode);
            return target;
        } else {
            Vector2 direction = ((Vector2)target.Position - (Vector2)startNode.Position).normalized;
            direction *= nodeDistance;

            nodePos = direction + new Vector2(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));

            Node newNode = new Node(nodePos);

            ConnectNodes(startNode, newNode);

            return BuildNodesToNode(target, newNode);
        }
    }

}
