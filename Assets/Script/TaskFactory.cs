using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFactory : MonoBehaviour {

    void taskCreate(Task task)
    {
        TaskList.Instance.taskList.Add(task);
    }

    private void Start()
    {
        StartCoroutine("e");
    }

    private IEnumerator e()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            taskCreate(new HaeRuokaa());
        }
    }
}
