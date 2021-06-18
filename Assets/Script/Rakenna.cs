using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Roy_T.AStar.Graphs;

public class Rakenna : Task
{
    public Rakenna(Node nod, GameObject buildin, float diff)
    {
        node = nod;
        building = buildin;
        difficulty = diff;
    }
    override public bool Do(Ant ant)
    {
        if (ant.currentNode == node && progress < 1)
        {
            progress += 1f / 30f * Time.fixedDeltaTime;
            if (progress > 1)
            {
                Building build = Object.Instantiate(building, node.Position, Quaternion.identity).GetComponent<Building>();
                build.node = node;
                TaskList.Instance.taskList.Remove(this);
                GameAIEventSystem.Instance.SendEvent(new GameAIEvent(building.name, GraphController.initialNode.Position, ant.gameObject));
            }
            Debug.Log(progress);
            Debug.Log(1f / 30f * Time.fixedDeltaTime);
        }
        else if (ant.currentPath == null && progress < 1) ant.moveToNode(node);
        return progress > 1;
    }
    float progress = 0;
    float difficulty;
    GameObject building;
    Node node;
}
