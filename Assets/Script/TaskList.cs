using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList
{
    private static TaskList _instance;

    public static TaskList Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TaskList();
            }

            return _instance;
        }
    }


    public static void AddTask(Task task) {
        Instance.taskList.Add(task);
    }

    public List<Task> taskList = new List<Task>();
}
