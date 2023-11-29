using System;
using System.Collections;
using System.Collections.Generic;

namespace PhoneBookApplication
{
    public class DirectoryOperationsManager : IDirectoryOperations
    {
        List<Person> persons = new List<Person>();

        public DirectoryOperationsManager() { 
            persons.Add(new Person("Emre", "Ünaldı", "05078711181"));
            persons.Add(new Person("Ali", "Turhal", "05078711182"));
            persons.Add(new Person("Ömer", "Gün", "05078711183"));
            persons.Add(new Person("Ahmet", "Yangel", "05078711184"));
            persons.Add(new Person("Mehmet", "Tecir", "05078711185"));
        }

        public void Add()
        {
            try
            {
                repeat:
                Console.WriteLine("|----------------- Telefon Numarası Kaydet ------------------|");
                Console.Write("Eklenecek kişinin adını girin : ");
                string firstName = Console.ReadLine();
                Console.Write("Eklenecek kişinin soyadı girin : ");
                string lastName = Console.ReadLine();
                Console.Write("Eklenecek kişinin telefon numarasını girin : ");
                string phoneNumber = Console.ReadLine();

                Console.WriteLine("Girilen bilgilerinin doğru olduğunu onaylıyor musunuz ?");
                Console.WriteLine($"(1) Evet, Kaydet\n(2) Kayıttan Vazgeç\n(3) Bilgileri Düzelt");
                ushort choose = Convert.ToUInt16(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Person person = new Person(firstName, lastName, phoneNumber);
                        persons.Add(person);
                        Console.WriteLine($"{person.FirstName} {person.LastName} kişisi rehbere kaydedildi.");
                        break;
                    case 2:
                        Console.WriteLine("Kayıt iptal edildi.");
                        return;
                    case 3:
                        goto repeat;
                    default:
                        Console.WriteLine("Lütfen bilgileri doğru giriniz!!!");
                        break;
                }
            } catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }

        public void Delete()
        {
            try
            {
            repeat:
                Console.WriteLine("|------------------ Telefon Numarası Sil --------------------|");
                Console.Write("Silmek istediğiniz kişinin adını veya soyadını giriniz : ");
                string personInfo = Console.ReadLine().ToLower().Trim();
                bool isFound = false;

                for (int i = 0; i < persons.Count; i++)
                {
                    if ((persons[i].FirstName.ToLower().Equals(personInfo)) || (persons[i].LastName.ToLower().Equals(personInfo)))
                    {
                        Console.WriteLine($"{persons[i].FirstName} {persons[i].LastName} kişisi rehberden silinecektir. Onaylıyor musunuz ?");
                        Console.WriteLine("(1) Evet \n(2) Hayır");
                        ushort isDelete = Convert.ToUInt16(Console.ReadLine());

                        if (isDelete == 1)
                        {
                            Console.WriteLine($"{persons[i].FirstName} {persons[i].LastName} kişisi rehberden silindi.");
                            persons.RemoveAt(i);
                            isFound = true;
                            break;
                        }
                        else 
                            return;
                    }
                } 

                if(!isFound)
                {
                    Console.WriteLine("Aradığınız kişi rehberde bulunmamaktadır.Tekrar denemek ister misiniz ?");
                    Console.WriteLine("(1) Evet \n(2) Hayır");
                    ushort isRepeat = Convert.ToUInt16(Console.ReadLine());

                    if (isRepeat == 1)
                        goto repeat;
                    else return;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }

        public void GetAll()
        {
            try
            {
                bool isExit = false;
                List<Person> sortedPersonList = new List<Person>();

                while (!isExit)
                {
                    Console.WriteLine("|---------------- Telefon Rehberini Listele -----------------|");
                    Console.WriteLine("(1) A-Z'ye Listele");
                    Console.WriteLine("(2) Z-A'ya Listele");
                    Console.WriteLine("(0) Ana Menüye Dön");
                    Console.Write("Rehberi nasıl sıralamak istediğnizi seçiniz : ");
                    ushort choose = Convert.ToUInt16(Console.ReadLine());

                    switch (choose)
                    {
                        case 0:
                            isExit = true;
                            break;
                        case 1:
                            sortedPersonList = persons.OrderBy(person => person.FirstName).ToList();
                            break;
                        case 2:
                            sortedPersonList = persons.OrderByDescending(person => person.FirstName).ToList();
                            break;
                        default:
                            Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                            break;
                    }

                    foreach (Person person in sortedPersonList)
                    {
                        Console.WriteLine("|------------------------------------------------------------|");
                        Console.WriteLine($"" +
                            $"Ad: {person.FirstName} - " +
                            $"Soyad: {person.LastName} - " +
                            $"Telefon Numarası: {person.PhoneNumber}");
                        Console.WriteLine("|------------------------------------------------------------|");
                    }
                }
            } 
            catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }

        public void GetByNameOrSurname()
        {
            try
            {
                repeat:
                Console.WriteLine("|-------------------- Rehberde Arama Yap --------------------|");
                Console.WriteLine("(1) Ad veya soyada göre arama yap : ");
                Console.WriteLine("(2) Telefon numarasına göre arama yap : ");
                ushort choose = Convert.ToUInt16(Console.ReadLine());
                bool isFound = false;

                switch (choose) 
                {
                    case 1:
                        Console.Write("Aramak istediğiniz kişinin adını veya soyadını giriniz : ");
                        string personInfo = Console.ReadLine().ToLower().Trim();

                        for (int i = 0; i < persons.Count; i++)
                        {
                            if ((persons[i].FirstName.ToLower().Equals(personInfo)) || (persons[i].LastName.ToLower().Equals(personInfo)))
                            {
                                isFound = true;
                                Console.WriteLine("|---------------------- Arama Sonuçları ---------------------|");
                                Console.WriteLine($"Kayıt bulundu\n" +
                                    $"Kişi Adı: {persons[i].FirstName}\n" +
                                    $"Kişi Soyadı: {persons[i].LastName}\n" +
                                    $"Kişi Telefon Numarası: {persons[i].PhoneNumber}\n");
                            }
                        }

                        if (!isFound)
                        {
                            Console.WriteLine("Aradığınız ad veya soyada sahip kişi rehberde bulunmamaktadır.Tekrar denemek ister misiniz ?");
                            Console.WriteLine("(1) Evet \n(2) Hayır");
                            ushort isRepeat = Convert.ToUInt16(Console.ReadLine());

                            if (isRepeat == 1)
                                goto repeat;
                            else return;
                        }
                        break;
                    case 2:
                        Console.Write("Aramak istediğiniz kişinin telefon numarasını giriniz : ");
                        string personPhoneNumber = Console.ReadLine().Trim();

                        for (int i = 0; i < persons.Count; i++)
                        {
                            if (persons[i].PhoneNumber.Equals(personPhoneNumber))
                            {
                                isFound = true;
                                Console.WriteLine("|---------------------- Arama Sonuçları ---------------------|");
                                Console.WriteLine($"Kayıt bulundu\n" +
                                    $"Kişi Adı: {persons[i].FirstName}\n" +
                                    $"Kişi Soyadı: {persons[i].LastName}\n" +
                                    $"Kişi Telefon Numarası: {persons[i].PhoneNumber}\n");
                            }
                        }

                        if (!isFound)
                        {
                            Console.WriteLine("Aradığınız telefon numarasına ait kişi rehberde bulunmamaktadır.Tekrar denemek ister misiniz ?");
                            Console.WriteLine("(1) Evet \n(2) Hayır");
                            ushort isRepeat = Convert.ToUInt16(Console.ReadLine());

                            if (isRepeat == 1)
                                goto repeat;
                            else return;
                        }
                        break;
                    default:
                        Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                        break;
                }
            }
            catch (Exception exception) 
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }

        public void Update()
        {
            try
            {
                repeat:
                Console.WriteLine("|---------------- Telefon Numarası Güncelle -----------------|");
                Console.Write("Güncellemek istediğiniz kişinin adını veya soyadını giriniz : ");
                string personInfo = Console.ReadLine().ToLower().Trim();
                bool isFound = false;

                for (int i = 0; i < persons.Count; i++)
                {
                    if ((persons[i].FirstName.ToLower().Equals(personInfo)) || (persons[i].LastName.ToLower().Equals(personInfo)))
                    {
                        updateRepeat:
                        Console.WriteLine($"{persons[i].FirstName} {persons[i].LastName} kişisi rehberde bulundu.");
                        Console.WriteLine("Kişinin hangi bilgisini güncellemek istiyorsunuz ?");
                        Console.WriteLine("(1) AD\n(2) SOYAD\n(3) TELEFON NUMARASI\n(4) Tüm Bilgiler\n(0) Güncellemekten Vazgeç");
                        ushort choose = Convert.ToUInt16(Console.ReadLine());
                        isFound = true;

                        switch (choose)
                        {
                            case 0:
                                return;
                            case 1:
                                Console.Write("Kişinin yeni adını girin : ");
                                string updateFirstName = Console.ReadLine();
                                persons[i].FirstName = updateFirstName;

                                Console.WriteLine($"Kişinin adı {persons[i].FirstName} olarak güncellenmiştir.");
                                break;
                            case 2:
                                Console.Write("Kişinin yeni soyadını girin : ");
                                string updateLastName = Console.ReadLine();
                                persons[i].LastName = updateLastName;

                                Console.WriteLine($"Kişinin soyadı {persons[i].LastName} olarak güncellenmiştir.");
                                break;
                            case 3:
                                Console.Write("Kişinin yeni telefon numarası girin : ");
                                string updatePhoneNumber = Console.ReadLine();
                                persons[i].PhoneNumber = updatePhoneNumber;

                                Console.WriteLine($"Kişinin telefon numarası {persons[i].PhoneNumber} olarak güncellenmiştir.");
                                break;
                            case 4:
                                Console.Write("Kişinin yeni adını girin : ");
                                string allUpdateFirstName = Console.ReadLine();
                                
                                Console.Write("Kişinin yeni soyadını girin : ");
                                string allUpdateLastName = Console.ReadLine();
                                
                                Console.Write("Kişinin yeni telefon numarası girin : ");
                                string allUpdatePhoneNumber = Console.ReadLine();

                                persons[i].FirstName = allUpdateFirstName;
                                persons[i].LastName = allUpdateLastName;
                                persons[i].PhoneNumber = allUpdatePhoneNumber;

                                Console.WriteLine($"Kayıt " +
                                    $"Ad: {persons[i].FirstName} " +
                                    $"Soyad: {persons[i].LastName} " +
                                    $"Telefon Numarası: {persons[i].PhoneNumber} olarak güncellenmiştir.");
                                break;
                            default:
                                Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                                goto updateRepeat;
                        }
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Aradığınız kişi rehberde bulunmamaktadır.Tekrar denemek ister misiniz ?");
                    Console.WriteLine("(1) Evet \n(2) Hayır");
                    ushort isRepeat = Convert.ToUInt16(Console.ReadLine());

                    if (isRepeat == 1)
                        goto repeat;
                    else return;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }
    }
}
