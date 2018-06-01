using System;
using System.Collections.Generic;

namespace TodoListLib
{
    [Serializable]
    public class Task
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public List<string> Tags { get; set; }

        public Task(string title, string description, DateTime deadline, List<string> tags)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            Tags = tags;
        }

        public Task() { }

        public override bool Equals(object obj)
        {
            if (Title == ((Task)obj).Title && Description == ((Task)obj).Description && Deadline == ((Task)obj).Deadline)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
