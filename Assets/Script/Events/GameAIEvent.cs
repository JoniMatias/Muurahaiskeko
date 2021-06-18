using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAIEvent {


    public string id {
        get;
        private set;
    }

    public Vector2 position {
        get;
        private set;
    }

    public Vector2 target {
        get;
        private set;
    }

    public GameObject sender {
        get;
        private set;
    }

    public GameAIEvent(string id, Vector2 position, GameObject sender) {
        this.id = id;
        this.position = position;
        this.sender = sender;
        this.target = Vector2.zero;
    }

    public GameAIEvent(string id, Vector2 position, GameObject sender, Vector2 target) {
        this.id = id;
        this.position = position;
        this.target = target;
        this.sender = sender;
    }

}
