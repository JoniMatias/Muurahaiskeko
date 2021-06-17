using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shmex : Task
{

    public Shmex()
    {
        maxAnts = 1;
    }
    override public bool Do(Ant ant)
    {
        if (!dict.ContainsKey(ant)) dict.Add(ant, false);
        if (!dict[ant] && ant.currentPath == null)
        {
            ant.moveToNode(Node.initialNode);
            dict[ant] = true;
        }
        if (ant.currentPath == null && dict[ant])
        {
            delay += Time.fixedDeltaTime;
            if (delay > 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    //Object.Instantiate()
                }
                return true;
            } 
        }
        return false;
    }
    Dictionary<Ant, bool> dict = new Dictionary<Ant, bool>();
    float delay;
}
