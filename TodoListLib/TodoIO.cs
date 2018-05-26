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
    } 
}
