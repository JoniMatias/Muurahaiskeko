using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Roy_T.AStar.Graphs;
using Roy_T.AStar.Paths;


public class Ant : MonoBehaviour {
    private Node currentNode;
    public Task currentTask = null;
    public Path currentPath = null;
    private int edgeIndex = 0;

    public float speed = 0.2f;



    private void Start() {
        currentNode = GraphController.initialNode;
    }

    private void StartMovement() {
        moveToPosition(new Vector2(6f, 4f));
    }

    private void Update() {
        if (currentTask == null) {
            foreach (Task t in TaskList.Instance.taskList) {
                if (t.fitness()) { currentTask = t; t.currentAnts++; break; }
            }
        }
        else {
            if(currentTask.Do(this)) currentTask=null;
        }


        
        if (currentPath != null && currentPath.Edges.Count > edgeIndex) {
            IEdge currentEdge = currentPath.Edges[edgeIndex];
            transform.position = Vector2.MoveTowards(transform.position, currentPath.Edges[edgeIndex].End.Position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, currentEdge.End.Position) < 0.1f) {
                edgeIndex++;
            }
        } else if (currentPath != null && currentPath.Edges.Count <= edgeIndex) {
            edgeIndex = 0;
            currentPath = null;
        }
    }

    public void moveToNode(Node node) {
        PathFinder finder = new PathFinder();
        Path path = finder.FindPath(currentNode, node, Roy_T.AStar.Primitives.Velocity.FromMetersPerSecond(speed));
        currentPath = path;
    }

    public void moveToPosition(Vector2 position) {
        PathFinder finder = new PathFinder();
        Node closestNode = GraphController.ClosestNodeToPosition(position);
        Node targetNode = GraphController.BuildNodesToPosition(position, closestNode);
        Path path = finder.FindPath(currentNode, targetNode, Roy_T.AStar.Primitives.Velocity.FromMetersPerSecond(speed));
        currentPath = path;
    }
}
