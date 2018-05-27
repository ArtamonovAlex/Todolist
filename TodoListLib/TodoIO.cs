using System;
using System.Collections.Generic;

namespace TodoListLib
{
    public class TodoIO
    {
        public static void PrintAll(TodoList list)
        {
            if (list != null && list.Tasks.Count != 0)
            {
                Console.WriteLine("Last tasks:");
                foreach (Task task in list.Tasks)
                {
                    PrintTask(task);
                }
            }
            else
            {
                Console.WriteLine("No tasks");
            }
        }

        private static void PrintTask(Task item)
        {
            Console.WriteLine($"Title: {item.Title}");
            Console.WriteLine($"Description: {item.Description}");
            Console.WriteLine($"Deadline: {item.Deadline:d}");
            Console.WriteLine($"Tags:");
            int counter = 1;
            foreach (string tag in item.Tags)
            {
                Console.WriteLine($"    {counter}: {tag}");
                counter++;
            }
            Console.WriteLine("-------------------------");
        }

        public static Task AddTask()
        {
            Console.WriteLine("New task:");
            Console.Write($"{"Title:",16} ");
            string title = Console.ReadLine();
            Console.Write($"{"Description:",22} ");
            string description = Console.ReadLine();
            DateTime date;
            while (true)
            {
                Console.Write($"{"Deadline in format dd.mm.yyyy:",40} ");
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Wrong input");
                    continue;
                }
                if (date >= DateTime.Now) break;
                Console.WriteLine("Sorry, you lost your time. Please, think of a new deadline.");
            }
            Console.WriteLine($"{"Tags (finish on empty line):",38} ");
            List<string> tags = new List<string> { };
            int counter = 1;
            do
            {
                Console.Write($"{counter,15}: ");
                counter++;
                tags.Add(Console.ReadLine());
            } while (tags[tags.Count - 1] != "");
            tags.Remove("");
            return new Task(title, description, date, tags);
        }

        public static string[] GetTags()
        {
            Console.Write("Input tags devided by whitespace: ");
            string input = Console.ReadLine();
            return input.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool FoundedTasks(List<Task> result)
        {
            Console.WriteLine("Results:");
            if (result.Count != 0)
            {
                foreach (Task item in result)
                {
                    PrintTask(item);
                }
                Console.WriteLine("Do you want to delete this tasks? Input 'y' if yes, other to continue");
                if (Console.ReadLine() == "y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("There are no tasks with this tags");
                return false;
            }
        }
    } 
}
