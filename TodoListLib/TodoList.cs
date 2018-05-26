using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace TodoListLib
{
    [Serializable]
    public class TodoList
    {
        public List<Task> Tasks;

        public TodoList() { }

        public TodoList(List<Task> tasks)
        {
            Tasks = tasks;
        }

        public void Sort()
        {
            Tasks.Sort((Task x, Task y) => x.Deadline.CompareTo(y.Deadline));
        }
    }
}
