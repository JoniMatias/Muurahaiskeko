using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Roy_T.AStar.Graphs;

using Roy_T.AStar.Primitives;

public class TaskFactory : MonoBehaviour, GameAIEventListener {
    public Building discoPrefab;
    public Building hospitalPrefab;
    public Building arenaPrefab;

    public Ant antPrefab;

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
            taskCreate(new HaeRuokaa());
            yield return new WaitForSeconds(15);
        }
    }


    public void ReceiveEvent(GameAIEvent e) {

        Debug.Log(e.id);

    }
}
