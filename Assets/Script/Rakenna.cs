using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rakenna : Task
{
    new public bool Do(Ant ant)
    {
        /*if(ant.node != node) ant.moveToNode(node)*/
        //else 
        if (progress < 1) {
            progress += 1 / 30 * Time.fixedDeltaTime;
            if (progress > 1) {
                Object.Instantiate(building, /*node.position*/Vector3.zero, Quaternion.identity);
                TaskList.Instance.taskList.Remove(this);
                }
        }
        return progress > 1;
    }
    int maxAnts = 5;
    float progress = 0;
    GameObject building;
    //Node node;
}
