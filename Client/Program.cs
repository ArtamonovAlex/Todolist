using System;
using System.Collections.Generic;
using TodoListLib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("Wrong arguments");
                return;
            }
            var client = new Editor.TodoEditorClient("NetTcpBinding_ITodoEditor");
            client.InitializeList(args[0]);
            bool isWorking = true;
            int option;
            while (isWorking)
            {
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("1.Add task\n2.Last tasks\n3.Find tasks by tags\n4.Load from .csv file\n5.Save in .csv format\n6.Exit");
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Wrong imput, choose the correct option");
                }
                switch (option)
                {
                    case 1:
                        {
                            client.AddTask(JsonConverter.ToJson(TodoIO.AddTask()));
                            client.SaveMain(args[0]);
                            Console.WriteLine("Task added!");
                            break;
                        }
                    case 2:
                        {
                            client.InitializeList(args[0]);
                            TodoList list = JsonConverter.GetObject<TodoList>(client.GetList());
                            TodoIO.PrintAll(list);
                            Console.WriteLine("All tasks printed!");
                            break;
                        }
                    case 3:
                        {
                            client.InitializeList(args[0]);
                            List<Task> tasks = JsonConverter.GetObject<List<Task>>(client.FindTasks(TodoIO.GetTags()));
                            if (TodoIO.FoundedTasks(tasks))
                            {
                                TodoList todo = JsonConverter.GetObject<TodoList>(client.GetList());
                                foreach (Task task in tasks)
                                {
                                    todo.Tasks.Remove(task);
                                }
                                client.DeleteTasks(JsonConverter.ToJson(todo));
                                client.SaveMain(args[0]);
                                Console.WriteLine("Deleted!");
                            }
                            break;
                        }
                    case 4:
                        {
                            string path = TodoIO.ReadPath();
                            if (path != "cancel")
                            {
                                try
                                {
                                    client.Load(path);
                                    Console.WriteLine("Loaded!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            client.InitializeList(args[0]);
                            string path = TodoIO.ReadPath();
                            if (path != "cancel")
                            {
                                try
                                {
                                    client.Save(path);
                                    Console.WriteLine("Saved!");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;
                        }
                    case 6:
                        {
                            client.SaveMain(args[0]);
                            Console.WriteLine("Goodbye!");
                            Console.ReadLine();
                            isWorking = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong imput, choose the correct option");
                            break;
                        }
                }
            }
        }
    }
}
