using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFactory : MonoBehaviour, GameAIEventListener {


    void taskCreate(Task task)
    {
        TaskList.Instance.taskList.Add(task);
    }

    private void Start()
    {
        StartCoroutine("e");

        GameAIEventSystem.Instance.RegisterForEvents(this);
    }

    private IEnumerator e()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            taskCreate(new HaeRuokaa());
        }
    }

    public void ReceiveEvent(GameAIEvent e) {

        

    }
}
