using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Roy_T.AStar.Graphs;

public class Building : MonoBehaviour
{
    public Node node;
    public static List<Building> buildArray = new List<Building>();
    private void Start()
    {
        buildArray.Add(this);
    }
}
