using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAIEventSystem : MonoBehaviour {

    private List<GameAIEventListener> listeners = new List<GameAIEventListener>();

    private List<GameAIEvent> events = new List<GameAIEvent>();

    void Start() {
        
    }

    void Update() {
        List <GameAIEvent> oldEvents = new List<GameAIEvent>(events);
        events.Clear();
        foreach (GameAIEvent e in oldEvents) {
            foreach (GameAIEventListener ai in listeners) {
                ai.ReceiveEvent(e);
            }
        }
    }

    public void SendEvent(GameAIEvent e) {
        events.Add(e);
    }

    public void RegisterForEvents(GameAIEventListener listener) {
        listeners.Add(listener);
    }
}
