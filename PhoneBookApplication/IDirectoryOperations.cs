using System;

namespace PhoneBookApplication
{
    public interface IDirectoryOperations
    {
        public void Add();
        public void Delete();
        public void Update();
        public void GetAll();
        public void GetByNameOrSurname();
    }
}
