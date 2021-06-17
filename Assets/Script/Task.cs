using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public bool Do(Ant ant)
    {
        return false;
    }
    int maxAnts = 5;
    public int currentAnts;
    public bool fitness()
    {
        return currentAnts < maxAnts;
    }
}
