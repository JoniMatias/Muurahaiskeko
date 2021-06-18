using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameAIEventListener {

    public abstract void ReceiveEvent(GameAIEvent e);
}
