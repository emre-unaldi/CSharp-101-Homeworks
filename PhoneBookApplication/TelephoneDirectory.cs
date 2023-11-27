using System;

namespace PhoneBookApplication
{
    public class TelephoneDirectory
    {
        bool isExit = false;
        IDirectoryOperations _directoryOperations;

        public TelephoneDirectory(IDirectoryOperations directoryOperations)
        {
            this._directoryOperations = directoryOperations;
        }

        public bool IsExit { get => isExit; set => isExit = value; }

        public void Start()
        {
            try
            {
                while (!IsExit)
                {
                    Console.WriteLine("|------------------------------------------------------------|");
                    Console.WriteLine("|--------- Telefon Rehberi Uygulamasına Hoşgeldiniz ---------|");
                    Console.WriteLine("|------------------------------------------------------------|");
                    Console.WriteLine("|------------------------------------------------------------|");
                    Console.WriteLine("(1) Telefon Numarası Kaydet");
                    Console.WriteLine("(2) Telefon Numarası Sil");
                    Console.WriteLine("(3) Telefon Numarası Güncelle");
                    Console.WriteLine("(4) Rehber Listeleme (A-Z | Z-A)");
                    Console.WriteLine("(5) Rehberde Arama");
                    Console.WriteLine("(0) Çıkış Yap");
                    Console.WriteLine("|------------------------------------------------------------|");
                    Console.Write("Yapmak İstediğiniz işlemi Seçiniz : ");
                    int choose = Convert.ToInt32(Console.ReadLine());

                    switch (choose)
                    {
                        case 0:
                            this.IsExit = true;
                            Console.WriteLine("Uygulama Sonlandırıldı...");
                            break;
                        case 1:
                            this._directoryOperations.Add();
                            break;
                        case 2:
                            this._directoryOperations.Delete();
                            break;
                        case 3:
                            this._directoryOperations.Update();
                            break;
                        case 4:
                            this._directoryOperations.GetAll();
                            break;
                        case 5:
                            this._directoryOperations.GetByNameOrSurname();
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
