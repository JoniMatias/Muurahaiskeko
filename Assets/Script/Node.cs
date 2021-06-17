using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    public Vector2 position { private set; get; }
    public HashSet<Node> neighbours { private set; get; }

    public Node() {
        neighbours = new HashSet<Node>();
    }

    public void AddNeighbour(Node n) {
        neighbours.Add(n);
    }
}
