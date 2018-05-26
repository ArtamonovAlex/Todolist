using System;
using TodoListLib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Editor.TodoEditorClient("NetTcpBinding_ITodoEditor");
            client.InitializeList("alex");
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
                        break;
                    case 2:
                        TodoList list = JsonConverter.GetObject<TodoList>(client.GetList());
                        TodoIO.PrintAll(list);
                        Console.WriteLine("All tasks printed!");

                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        Console.ReadLine();
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Wrong imput, choose the correct option");
                        break;
                }
            }
        }
    }
}

