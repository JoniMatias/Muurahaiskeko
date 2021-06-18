using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAIEvent {

    public class Events {
        public class Offensive {
            public const string hitBall = "hit";
            public const string startRunning = "run";
            public const string stopRunning = "stop";
            public const string atBase = "base";
            public const string backHome = "backHome";
            public const string iOut = "iOut";
        }

        public class Defensive {
            public const string caught = "catch";
            public const string caughtWithoutBounce = "catchNoBounce";
            public const string leaveBase = "leave";
            public const string willFillBase = "fillingBase";
            public const string cancelFillBase = "cancelBase";
            public const string toss = "throw";
            public const string toMe = "toMe";
            public const string notToMe = "notToMe";
            public const string iWill = "iWill";
            public const string iWont = "iWont";
            public const string serve = "serve";
            public const string fakeServe = "fakeOut";
            public const string arrivedAtBase = "catcherAtBase";
            public const string ballAtBase = "ballAtBase";
        }

        public class Ball {
            public const string launch = "launch";
            public const string bounce = "bounce";
            public const string stop = "stop";
            public const string caught = "stopCaught";
        }

        public class Base {
            public const string canBurn = "canBurn";
            public const string cantBurn = "cantBurn";
        }

        public class Game {
            public const string foul = "foul";
            public const string wounded = "wounded";
            public const string strike = "strike";
            public const string endRun = "endRun";
            public const string endInning = "endInning";
            public const string endGame = "endGame";
            public const string startRun = "startRun";
            public const string outBurn = "out";
        }
    }


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
