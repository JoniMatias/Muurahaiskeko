using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Roy_T.AStar.Graphs;
using Roy_T.AStar.Paths;


public class Ant : MonoBehaviour {
    public Node currentNode;
    public Task currentTask = null;
    public Path currentPath = null;
    private int edgeIndex = 0;

    public AntAnimator animator;

    public float speed = 0.2f;

    private GameAIEventSystem eventSystem;



    private void Start() {
        currentNode = GraphController.initialNode;
        transform.position = Vector2.zero;
        Invoke("StartMovement", 0.2f);
        eventSystem = GameAIEventSystem.Instance;
        eventSystem.SendEvent(new GameAIEvent("Syntyi", transform.position, gameObject));
    }

    private void OnDestroy() {
        eventSystem.SendEvent(new GameAIEvent("Kuoli", transform.position, gameObject));
    }

    private void StartMovement() {
        //moveToNode(GraphController.foodNodes[0]);
        //moveToPosition(new Vector2(6f, 4f));
    }

    private void Update() {
        if (currentTask == null) {
            foreach (Task t in TaskList.Instance.taskList) {
                if (t.fitness()) { currentTask = t; t.currentAnts++; break; }
            }
        }
        else {
            if (currentTask.Do(this))
            {
                currentTask.currentAnts--;
                currentTask = null;
            }
        }

        if (currentPath != null && currentPath.Edges.Count > edgeIndex) {
            animator.isWalking = true;
            IEdge currentEdge = currentPath.Edges[edgeIndex];
            transform.position = Vector2.MoveTowards(transform.position, currentPath.Edges[edgeIndex].End.Position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, currentEdge.End.Position) < 0.1f) {
                edgeIndex++;
                currentNode = (Node)currentEdge.End;
            }
        } else if (currentPath != null && currentPath.Edges.Count <= edgeIndex) {
            edgeIndex = 0;
            currentPath = null;
            animator.isWalking = false;
        }
    }

    public void moveToNode(Node node, bool recall = false) {
        PathFinder finder = new PathFinder();
        Path path = finder.FindPath(currentNode, node, Roy_T.AStar.Primitives.Velocity.FromMetersPerSecond(speed*2));

        if (path.Edges.Count > 0) {
            currentPath = path;
        } else if (recall == false) {
            Node closestNode = GraphController.ClosestNodeToPosition(node.Position);
            Node targetNode = GraphController.BuildNodesToNode(node, closestNode);
            moveToNode(targetNode, true);
        } else if (recall == true) {
            Debug.Log("Ant stranded " + gameObject);
        }
    }

    public void moveToPosition(Vector2 position) {
        PathFinder finder = new PathFinder();
        Node closestNode = GraphController.ClosestNodeToPosition(position);
        Node targetNode = GraphController.BuildNodesToNode(new Node(position), closestNode);
        Path path = finder.FindPath(currentNode, targetNode, Roy_T.AStar.Primitives.Velocity.FromMetersPerSecond(speed));
        currentPath = path;
    }
}
