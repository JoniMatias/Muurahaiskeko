using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public Vector2 position { private set; get; }
    public HashSet<Node> neighbours { private set; get; }

    private static Node _initialNode = null;

    public static Node initialNode {
        get {
            if (_initialNode == null) {
                _initialNode = new Node(Vector2.zero);
            }
            return _initialNode;
        }
    }

    public Node(Vector2 position) {
        this.position = position;
        neighbours = new HashSet<Node>();
    }

    public void AddNeighbour(Node n) {
        neighbours.Add(n);
    }
}
