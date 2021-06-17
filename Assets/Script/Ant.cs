using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour {
    public Node currentNode;
    private Task currentTask = null;
    public Path currentPath = null;

    public float speed = 2f;



    private void Start() {
        currentNode = Node.initialNode;
        transform.position = Vector2.zero;
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
        /*
        if (currentPath != null && currentPath.AtGoal() == false) {
            transform.position = Vector2.MoveTowards(transform.position, currentPath.CurrentTarget().position, speed * Time.deltaTime);
        } else if (currentPath != null && currentPath.AtGoal()) {
            currentPath = null;
        }*/
    }

    public void moveToNode(Node node) {

        currentNode=node;
        transform.position = node.position;
    }

    public void moveToPosition(Vector2 position) {
        transform.position = position;
    }
}
