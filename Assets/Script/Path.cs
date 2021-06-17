using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path  {

    public List<Node> points = new List<Node>();
    public bool isUnfinished { get; private set; } //Eli tämän AStar-algoritmi ei löytänyt polkua ennen kuin rajoittimet tulivat vastaan.

    private int nextNode = 1;

    public Path(List<Node> pathPoints, bool unfinished = false) {
        points = pathPoints;
        isUnfinished = unfinished;
    }

    public static Path EmptyPath() {
        return new Path(new List<Node>());
    }

    public void NextNode() {
        nextNode++;
    }

    public bool AtGoal() {
        return nextNode >= points.Count;
    }

    public Node CurrentTarget() {
        if (nextNode < points.Count) {
            return points[nextNode];
        }
        return null;
    }

    public Node Goal() {
        return points[points.Count];
    }

    public Vector2 NextDirection(Vector2 currentPosition) {
        Node target = CurrentTarget();
        if (target != null) {
            return (CurrentTarget().position - currentPosition).normalized;
        } else {
            return Vector2.zero;
        }
    }

}
