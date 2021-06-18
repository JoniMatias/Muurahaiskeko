using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Roy_T.AStar.Graphs;
using Roy_T.AStar.Primitives;
public class TaskFactory : MonoBehaviour, GameAIEventListener
{
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
        GameAIEventSystem.Instance.RegisterForEvents(this);
    }

    private IEnumerator e()
    {
        while (true)
        {
            if (potentiaaliruoka < 2)
            {
                taskCreate(new HaeRuokaa());
                potentiaaliruoka = potentiaaliruoka + 5;
            }
            yield return new WaitForSeconds(5);
        }
    }

    int potentiaaliruoka = 0;
    int ruuanmaara = 0;
    int hospitalmaara = 0;

    public void ReceiveEvent(GameAIEvent e)
    {
        Debug.Log(e.id);
        if (e.id == "Ruokaa")
        {
            ruuanmaara = ruuanmaara + 1;
            potentiaaliruoka = potentiaaliruoka - 1;

            if (ruuanmaara > 3)
            {
                float x = Random.Range(-5f, 5f);
                float y = Random.Range(-5f, 5f);
                TaskList.AddTask(new Rakenna(new Node(new Position(x, y)), hospitalPrefab.gameObject, 12));
                ruuanmaara = ruuanmaara - 3;
            }
            if(Random.value < 0.1f) TaskList.AddTask(new Shmex());
        }

        if (e.id == "Hospital")
        {
            hospitalmaara = hospitalmaara + 1;


            if (hospitalmaara > 1)
            {
                Debug.Log("Rakenna se typera Disco!" + TaskList.Instance.taskList.Count);
                float x = Random.Range(-5f, 5f);
                float y = Random.Range(-5f, 5f);
                TaskList.AddTask(new Rakenna(new Node(new Position(x, y)), discoPrefab.gameObject, 12));
                hospitalmaara = hospitalmaara - 2;
            }
        }
    }
}
