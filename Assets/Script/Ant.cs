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
    private Vector2 lastpath;
    public GameObject path;
    private Transform pathHolder;
    public AntAnimator animator;
    public GameObject prefab;
    public string mood;
    public string[] possibleMoods;
    private float munchCD=3;

    public float speed = 0.2f;

    private GameAIEventSystem eventSystem;



    private void Start() {
        currentNode = GraphController.initialNode;
        transform.position = Vector2.zero;
        Invoke("StartMovement", 0.2f);
        eventSystem = GameAIEventSystem.Instance;
        eventSystem.SendEvent(new GameAIEvent("Syntyi", transform.position, gameObject));
        pathHolder = GameObject.Find("PathHolder").transform;
        mood = possibleMoods[Random.Range(0, possibleMoods.Length)];
    }

    private void OnDestroy() {
        eventSystem.SendEvent(new GameAIEvent("Kuoli", transform.position, gameObject));
    }

    private void StartMovement() {
        //moveToNode(GraphController.foodNodes[0]);
        //moveToPosition(new Vector2(6f, 4f));
    }

    private void Update() {
        if (munchCD > 0) munchCD -= Time.deltaTime;
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
            transform.right = currentEdge.End.Position - transform.position;
            Vector3 scal = transform.localScale;
            if (currentEdge.End.Position.X < transform.position.x) scal.y = -1;
            else scal.y = 1;
            transform.localScale = scal;
            if (Vector2.Distance(lastpath, transform.position) > 0.2f)
            {
                Instantiate(path, transform.position, Quaternion.LookRotation(Vector3.forward, currentEdge.End.Position - transform.position)).transform.parent = pathHolder;
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
            moveToNode(node, true);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (mood == "angry" && collision.transform.GetComponent<Ant>().mood == "angry")
        {
            GameAIEventSystem.Instance.SendEvent(new GameAIEvent("fight", transform.position, gameObject));
        }
        if(mood == "cannibal" && munchCD <= 0)
        {
            GameAIEventSystem.Instance.SendEvent(new GameAIEvent("munch", transform.position, gameObject));
            Destroy(collision.gameObject);
            munchCD = 3f;
        }
    }
}
