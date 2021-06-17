using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInitializer : MonoBehaviour {

    private static NodeInitializer _instance;

    public static NodeInitializer Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<NodeInitializer>();
            }

            return _instance;
        }
    }

    public void Awake() {
        /*
        Roy_T.AStar.Graphs.Node node = GraphController.initialNode;

        Roy_T.AStar.Graphs.Node prevNode = node;

        for (int x=0; x<2; ++x) {
            for (int y=0; y<2; ++y) {
                Roy_T.AStar.Graphs.Node newNode = new Roy_T.AStar.Graphs.Node(new Roy_T.AStar.Primitives.Position(x,y));
                GraphController.ConnectNodes(prevNode, newNode);

                prevNode = newNode;
            }
        }
        */

    }

}
