using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    } 
}
