using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaeRuokaa : Task
{
    override public bool Do(Ant ant)
    {
        if (!dict.ContainsKey(ant)) dict.Add(ant, 0);
        if (ant.currentPath == null && dict[ant] == 2)
        {
            Debug.Log("c");
            dict[ant] = 0;
            return true;
        }
        if (ant.currentPath == null && dict[ant] == 1)
        {
            Debug.Log("b");
            food++;
            if (food > 4)
            {
                TaskList.Instance.taskList.Remove(this);
            }
            ant.moveToNode(Node.initialNode);
            dict[ant]++;
        }
        if (dict[ant] == 0 && ant.currentPath == null)
        {
            Debug.Log("a");
            ant.moveToPosition(TaskFactory.foodPositions[Random.Range(0, 6)]);
            dict[ant]++;
        }
        return false;
    }
    Dictionary<Ant, int> dict = new Dictionary<Ant, int>();
    int food;
    override public bool fitness()
    {
        return currentAnts+food<5;
    }
}
