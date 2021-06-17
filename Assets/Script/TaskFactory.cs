using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskFactory : MonoBehaviour
{
    public static Vector2[] foodPositions = new Vector2[] { new Vector2(-11, -3), new Vector2(-11, 0), new Vector2(-11, 3), new Vector2(11, -3), new Vector2(11, 0), new Vector2(11, 3) };
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
