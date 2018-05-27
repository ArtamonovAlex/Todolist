using System;
using System.Collections.Generic;
using System.IO;

namespace TodoListLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "TodoEditor" в коде и файле конфигурации.
    public class TodoEditor : ITodoEditor
    {
        public TodoList List = new TodoList(new List<Task>());

        public void InitializeList(string tableName)
        {
            string privatePath = $"C:\\Users\\artam\\Desktop\\list{tableName}.csv";
            Load(privatePath);
        }

        public string GetList()
        {
            return JsonConverter.ToJson(List);
        }

        public string GetTask(Task task)
        {
            return JsonConverter.ToJson(task);
        }

        public void AddTask(string task)
        {
            List.Tasks.Add(JsonConverter.GetObject<Task>(task));
            List.Sort();
        }

        public string FindTasks(string[] tags)
        {
            List<Task> result = List.Tasks.FindAll(delegate (Task c)
            {
                int counter = 0;
                foreach (string tag in tags)
                {
                    if (c.Tags.Contains(tag)) counter++;
                }
                if (counter == tags.Length) return true;
                else return false;
            });
            return JsonConverter.ToJson(result);
        }

        public void DeleteTasks(string tasks)
        {
            List = JsonConverter.GetObject<TodoList>(tasks);
        }

        public void Save(string path)
        {
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine("Title;Description;Deadline;Tags");
                foreach (Task item in List.Tasks)
                {
                    writer.Write(item.Title + ";");
                    writer.Write(item.Description + ";");
                    writer.Write(item.Deadline.ToShortDateString());
                    foreach (string tag in item.Tags)
                    {
                        writer.Write(";" + tag);
                    }
                    writer.WriteLine();
                }
            }
            file.Close();
        }

        public void SaveMain(string tableName)
        {
            string privatePath = $"C:\\Users\\artam\\Desktop\\list{tableName}.csv";
            Save(privatePath);
        }

        public void Load(string path)
        {
            List<Task> tasks = new List<Task> { };
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(file))
            {
                reader.ReadLine();
                char[] separator = { ';' };
                while (!reader.EndOfStream)
                {
                    string inputString = reader.ReadLine();
                    string[] elements = inputString.Split(separator);
                    string title = elements[0];
                    string description = elements[1];
                    DateTime date = DateTime.Parse(elements[2]);
                    List<string> tags = new List<string> { };
                    for (int i = 3; i < elements.Length; i++)
                    {
                        string tag = elements[i];
                        tags.Add(tag);
                    }
                    Task task = new Task(title, description, date, tags);
                    tasks.Add(task);
                }
            }
            file.Close();
            List.Tasks = tasks;
        }
    }
}
