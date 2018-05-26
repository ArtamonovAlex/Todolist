using System;
using System.Collections.Generic;
using System.IO;

namespace TodoListLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "TodoEditor" в коде и файле конфигурации.
    public class TodoEditor : ITodoEditor
    {
        public TodoList List = new TodoList(new List<Task>() { new Task("test", "test", DateTime.Parse("12.12.2018"), new List<string>() { "1" }) } );

        public void InitializeList(string username)
        {
            List<Task> tasks = new List<Task>();
            string path = $"C:\\Users\\artam\\Desktop\\list{username}.csv";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
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

        public string GetList()
        {
            return JsonConverter.ToJson(List);
        }

        public string GetTask(Task task)
        {
            return JsonConverter.ToJson(task);
        }
    }
}
