using System;

namespace ToDoApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            ToDo toDo = new ToDo(new ToDoManager());
            toDo.Start();
        }
    }
}