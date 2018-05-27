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
            if (!client.InitializeList(args[0]))
            {
                Console.WriteLine("Can't access file. Abort process");
                return;
            }
            bool isWorking = true;
            while (isWorking)
            {
                switch (TodoIO.GetMenuOption())
                {
                    case 1:
                        {
                            client.AddTask(JsonConverter.ToJson(TodoIO.AddTask()));
                            if (!client.SaveMain(args[0]))
                            {
                                Console.WriteLine("Can't save changes. They won't be avaliable to other clients.");

                            }
                            else
                            {
                                Console.WriteLine("Task added!");
                            }
                            break;
                        }
                    case 2:
                        {
                            if (!client.InitializeList(args[0]))
                            {
                                Console.WriteLine("Can't access file. Abort process");
                                break;
                            }
                            TodoList list = JsonConverter.GetObject<TodoList>(client.GetList());
                            TodoIO.PrintAll(list);
                            Console.WriteLine("All tasks printed!");
                            break;
                        }
                    case 3:
                        {
                            if (!client.InitializeList(args[0]))
                            {
                                Console.WriteLine("Can't access file. Abort process");
                                break;
                            }
                            List<Task> tasks = JsonConverter.GetObject<List<Task>>(client.FindTasks(TodoIO.GetTags()));
                            if (TodoIO.FoundedTasks(tasks))
                            {
                                TodoList todo = JsonConverter.GetObject<TodoList>(client.GetList());
                                foreach (Task task in tasks)
                                {
                                    todo.Tasks.Remove(task);
                                }
                                client.DeleteTasks(JsonConverter.ToJson(todo));
                                if (!client.SaveMain(args[0]))
                                {
                                    Console.WriteLine("Can't save changes. They won't be avaliable to other clients.");

                                }
                                else
                                {
                                    Console.WriteLine("Deleted!");
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            string path = TodoIO.ReadPath();
                            if (path != "cancel")
                            {
                                if (!client.Load(path))
                                {
                                    Console.WriteLine("Can't access file. Abort process");
                                    break;
                                }
                                Console.WriteLine("Loaded!");
                            }
                            break;
                        }
                    case 5:
                        {
                            if (!client.InitializeList(args[0]))
                            {
                                Console.WriteLine("Can't access file. Abort process");
                                break;
                            }
                            string path = TodoIO.ReadPath();
                            if (path != "cancel")
                            {
                                if (!client.SaveMain(args[0]))
                                {
                                    Console.WriteLine("Can't save changes. They won't be avaliable to other clients.");
                                    break;
                                }
                                Console.WriteLine("Saved!");
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
