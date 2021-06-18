using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Roy_T.AStar.Graphs;
public class TaskFactory : MonoBehaviour, GameAIEventListener {
    public Building discoPrefab;
    public Building hospitalPrefab;
    public Building arenaPrefab;

    void taskCreate(Task task)
    {
        TaskList.Instance.taskList.Add(task);
    }

    private void Start()
    {
        StartCoroutine("e");
        taskCreate(new Shmex());
        GameAIEventSystem.Instance.RegisterForEvents(this);
    }

    private IEnumerator e()
    {
        while (true)
        {
            taskCreate(new HaeRuokaa());
            yield return new WaitForSeconds(3);
            if(Random.value<0.1) taskCreate(new Shmex());   
        }
    }

    public void ReceiveEvent(GameAIEvent e) {
        Debug.Log(e.id);

    }
}
