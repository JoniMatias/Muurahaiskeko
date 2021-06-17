using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public virtual bool Do(Ant ant)
    {
        return false;
    }
    protected int maxAnts = 5;
    public int currentAnts;
    public virtual bool fitness()
    {
        return currentAnts < maxAnts;
    }
}
