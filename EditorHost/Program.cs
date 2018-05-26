using System;
using System.ServiceModel;

namespace EditorHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(TodoListLib.TodoEditor)))
            {
                host.Open();
                Console.WriteLine("Host is online");
                Console.ReadLine();
            }
        }
    }
}
