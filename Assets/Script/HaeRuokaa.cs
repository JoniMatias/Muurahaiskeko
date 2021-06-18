using Roy_T.AStar.Graphs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaeRuokaa : Task
{
    override public bool Do(Ant ant)
    {
        if (!dict.ContainsKey(ant)) dict.Add(ant, 0);
        if (ant.currentPath == null && dict[ant] == 3)
        {
            dict[ant] = 0;
            GameAIEventSystem.Instance.SendEvent(new GameAIEvent("Ruokaa", GraphController.initialNode.Position, ant.gameObject));
            return true;
        }
        if (ant.currentPath != null && dict[ant] == 2)
        {
            //Debug.Log("c");
            dict[ant]++;
        }
        if (ant.currentPath == null && dict[ant] == 1)
        {
            //Debug.Log("b");
            food++;
            if (food > 4)
            {
                TaskList.Instance.taskList.Remove(this);
            }
            ant.moveToNode(GraphController.initialNode);
            dict[ant]++;
        }
        if (dict[ant] == 0 && ant.currentPath == null)
        {
            //Debug.Log("a");
            Node node = GraphController.foodNodes[Random.Range(0, GraphController.foodNodes.Count)];
            ant.moveToNode(node);
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
