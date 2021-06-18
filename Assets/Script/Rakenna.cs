using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Roy_T.AStar.Graphs;

public class Rakenna : Task
{
    override public bool Do(Ant ant)
    {
        if (ant.currentPath == null) ant.moveToNode(node);
        else if (ant.currentNode==node && progress < 1) {
            progress += 1 / 30 * Time.fixedDeltaTime;
            if (progress > 1)
            {
                Building build = Object.Instantiate(building, node.Position, Quaternion.identity).GetComponent<Building>();
                build.node = node;
                TaskList.Instance.taskList.Remove(this);
            }
        }
        return progress > 1;
    }
    float progress = 0;
    GameObject building;
    Node node;
}
