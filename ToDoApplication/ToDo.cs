using System;

namespace ToDoApplication
{
    public class ToDo
    {
        private bool isExit = false;
        IToDoActions _toDoActions;

        public ToDo(IToDoActions toDoActions)
        {
            _toDoActions = toDoActions;
        }

        public bool IsExit { get => isExit; set => isExit = value; }

        public void Start()
        {
            try
            {
                while (!IsExit)
                {
                    Console.WriteLine("|------------------------------------------------|");
                    Console.WriteLine("|------------------ To Do List ------------------|");
                    Console.WriteLine("|------------------------------------------------|");
                    Console.WriteLine("(1) Panoya Kart Ekleme");
                    Console.WriteLine("(2) Panodan Kart Güncelleme");
                    Console.WriteLine("(3) Panodan Kart Silme");
                    Console.WriteLine("(4) Panoda Kart Taşımak");
                    Console.WriteLine("(5) Panoyu Listeleme");
                    Console.WriteLine("(0) Çıkış Yap");
                    Console.WriteLine("|------------------------------------------------|");
                    Console.Write("Yapmak İstediğiniz işlemi Seçiniz : ");
                    ushort choose = Convert.ToUInt16(Console.ReadLine());

                    switch (choose)
                    {
                        case 0:
                            this.IsExit = true; 
                            break;
                        case 1:
                            this._toDoActions.Add();
                            break;  
                        case 2:
                            this._toDoActions.Update();
                            break;  
                        case 3:
                            this._toDoActions.Delete();
                            break;  
                        case 4:
                            this._toDoActions.Move();
                            break;  
                        case 5:
                            this._toDoActions.GetAll();
                            break;  
                        default:
                            Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                            break;
                    }
                }
            }
            catch(Exception exception) 
            { 
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }
    }
}
