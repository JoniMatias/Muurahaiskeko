using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    //private Node currentNode;
    Task currentTask;
    private void Update()
    {
        if (currentTask == null)
        {
            foreach (Task t in TaskList.Instance.taskList)
            {
                if (t.fitness()) { currentTask = t; t.currentAnts++; break; }
            }
        }
        else
        {
            if(currentTask.Do(this)) currentTask=null;
        }
    }
    public void moveToNode()
    {

    }

    public void moveToPosition()
}
