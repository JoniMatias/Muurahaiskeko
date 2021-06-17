using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    void Suorita(/*Ant ant*/)
    {

    }
    int maxAnts = 5;
    int currentAnts;
    bool fitness()
    {
        return currentAnts < maxAnts;
    }
}
