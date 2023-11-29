using System;

namespace ToDoApplication
{
    public interface IToDoActions
    {
        public void Add();
        public void Update();
        public void Delete();
        public void Move();
        public void GetAll();
    }
}
