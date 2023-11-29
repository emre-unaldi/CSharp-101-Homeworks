using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDoApplication
{
    public class ToDoManager : IToDoActions
    {
        List<Member> teams = new List<Member>();
        List<Card> cards = new List<Card>();
        public ToDoManager() 
        {
            teams.Add(new Member(1, "Emre", "Ünaldı"));
            teams.Add(new Member(2, "Ali", "Turhal"));
            teams.Add(new Member(3, "Ömer", "Gün"));

            cards.Add(new Card("Java", "Spring Boot", Sizes.XL, teams[0], Status.TODO));
            cards.Add(new Card("CSharp", ".Net", Sizes.L, teams[1], Status.IN_PROGRESS));
            cards.Add(new Card("TypeScript", "React", Sizes.M, teams[2], Status.DONE));
        }
        public void Add()
        {
            try
            {
                repeat:
                Console.WriteLine("|-------------- Panoya Kart Ekleme --------------|");

                Console.Write("Başlık giriniz : ");
                string title = Console.ReadLine();

                Console.Write("İçerik giriniz : ");
                string content = Console.ReadLine();

                repeatSize:
                Console.WriteLine("(1) XS, (2) S, (3) M, (4) L, (5) XL");
                Console.Write("Biyüklük seçiniz : ");
                ushort selectedSize = (ushort)(Convert.ToUInt16(Console.ReadLine()) - 1);
                Sizes size;
                if (selectedSize < 5)
                {
                    size = Operations.SelectSize(selectedSize);
                }
                else
                {
                    Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                    goto repeatSize;
                }

                repeatMember:
                for (int i = 0; i < teams.Count; i++)
                {
                    Console.WriteLine($"({i + 1}) {teams[i].FirstName} {teams[i].LastName}");
                }
                Console.Write("Kişi seçiniz :");
                ushort selectedMember = (ushort)(Convert.ToUInt16(Console.ReadLine()) - 1);
                Member member;
                if(selectedMember < teams.Count) 
                { 
                    member = teams[selectedMember];
                }
                else
                {
                    Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                    goto repeatMember;
                }

                Console.WriteLine("Girilen kart bilgilerinin doğru olduğunu onaylıyor musunuz ?");
                Console.WriteLine($"(1) Evet, Kaydet\n(2) Kayıttan Vazgeç\n(3) Bilgileri Düzelt");
                ushort choose = Convert.ToUInt16(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Card card = new Card(title, content, size, member, Status.TODO);
                        cards.Add(card);
                        Console.WriteLine("Panoya Kart Eklendi.");
                        Operations.PrintCard(card);
                        break;
                    case 2:
                        Console.WriteLine("Kayıt iptal edildi.");
                        return;
                    case 3:
                        goto repeat;
                    default:
                        Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                        break;
                }         
            }
            catch(Exception exception) 
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }

        public void Delete()
        {
            try
            {
                repeat:
                Console.WriteLine("|-------------- Panodan Kart Silme --------------|");
                Console.Write("Silmek istediğiniz kart başlığını yazınız : ");
                string cardTitle = Console.ReadLine().ToLower().Trim();
                bool isFound = false;

                for(int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].Title.ToLower().Equals(cardTitle))
                    {
                        Console.WriteLine("|************ Bulunan Kart Bilgileri ************|");
                        Operations.PrintCard(cards[i]);
                        isFound = true;

                        Console.WriteLine($"{cards[i].Title} başlıklı kart silinecektir. Onaylıyor musunuz ?");
                        Console.WriteLine("(1) Evet \n(2) Hayır");
                        ushort isDelete = Convert.ToUInt16(Console.ReadLine());

                        if (isDelete == 1)
                        {
                            Console.WriteLine($"{cards[i].Title} başlıklı kart silindi.");
                            cards.RemoveAt(i);
                            break;
                        }
                        else
                            return;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Aradığınız başlığa sahip bir kart bulunmamaktadır.Tekrar denemek ister misiniz ?");
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
                var groupedCards = cards.GroupBy((card) => card.Status);

                Console.WriteLine("|************************************************|");
                foreach (var group in groupedCards)
                {
                    switch (group.Key)
                    {
                        case Status.TODO:
                            Console.WriteLine("|--------------------- TODO ---------------------|");
                            break;
                        case Status.IN_PROGRESS:
                            Console.WriteLine("|------------------ IN PROGRESS -----------------|");
                            break;
                        case Status.DONE:
                            Console.WriteLine("|--------------------- DONE ---------------------|");
                            break;
                    }

                    foreach(Card card in group)
                    {
                        Operations.PrintCard(card);
                    }
                }
                Console.WriteLine("|************************************************|");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }

        public void Move()
        {
            try
            {
            repeat:
                Console.WriteLine("|-------------- Panoda Kart Taşımak -------------|");
                Console.Write("Taşımak istediğiniz kart başlığını yazınız : ");
                string cardTitle = Console.ReadLine().ToLower().Trim();
                bool isFound = false;

                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].Title.ToLower().Equals(cardTitle))
                    {
                        Console.WriteLine("|************ Bulunan Kart Bilgileri ************|");
                        Operations.PrintCard(cards[i]);
                        isFound = true;

                        Console.WriteLine("(1)TODO - (2)IN PROGRESS - (3)DONE");    
                        Console.WriteLine("Lütfen taşımak istediğiniz bölümü seçin : ");
                        ushort selectedStatus = (ushort)(Convert.ToUInt16(Console.ReadLine()) - 1);

                        Console.WriteLine(
                            $"{cards[i].Title} başlıklı kartın bölümü " +
                            $"{cards[i].Status}'dan " +
                            $"{Operations.SelectStatus(selectedStatus)}'a taşınacaktır. Onaylıyor musunuz ?"
                        );
                        Console.WriteLine("(1) Evet \n(2) Hayır");
                        ushort isMove = Convert.ToUInt16(Console.ReadLine());

                        if (isMove == 1)
                        {
                            Console.WriteLine($"{cards[i].Title} başlıklı kart {Operations.SelectStatus(selectedStatus)}'a taşındı.");
                            cards[i].Status = Operations.SelectStatus(selectedStatus);
                            break;
                        }
                        else
                            return;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Aradığınız başlığa sahip bir kart bulunmamaktadır.Tekrar denemek ister misiniz ?");
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

        public void Update()
        {
            try
            {
                repeat:
                Console.WriteLine("|------------ Panodan Kart Güncelleme -----------|");
                Console.Write("Güncellemek istediğiniz kart başlığını yazınız : ");
                string cardTitle = Console.ReadLine().ToLower().Trim();
                bool isFound = false;

                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].Title.ToLower().Equals(cardTitle))
                    {
                        updateRepeat:
                        Console.WriteLine("|************ Bulunan Kart Bilgileri ************|");
                        Operations.PrintCard(cards[i]);
                        isFound = true;

                        Console.Write("Yeni başlık giriniz : ");
                        string updateTitle = Console.ReadLine();

                        Console.Write("Yeni içerik giriniz : ");
                        string updateContent = Console.ReadLine();

                        repeatSize:
                        Console.WriteLine("(1) XS, (2) S, (3) M, (4) L, (5) XL");
                        Console.Write("Yeni büyüklük seçiniz : ");
                        ushort updateSelectedSize = (ushort)(Convert.ToUInt16(Console.ReadLine()) - 1);
                        Sizes updateSize;
                        if (updateSelectedSize < 5)
                        {
                            updateSize = Operations.SelectSize(updateSelectedSize);
                        }
                        else
                        {
                            Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                            goto repeatSize;
                        }

                        repeatMember:
                        for (int j = 0; j < teams.Count; j++)
                        {
                            Console.WriteLine($"({j + 1}) {teams[j].FirstName} {teams[j].LastName}");
                        }
                        Console.Write("Yeni kişi seçiniz :");
                        ushort updateSelectedMember = (ushort)(Convert.ToUInt16(Console.ReadLine()) - 1);
                        Member updateMember;
                        if (updateSelectedMember < teams.Count)
                        {
                            updateMember = teams[updateSelectedMember];
                        }
                        else
                        {
                            Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                            goto repeatMember;
                        }

                        Console.WriteLine("Girilen kart bilgilerinin doğru olduğunu onaylıyor musunuz ?");
                        Console.WriteLine($"(1) Evet, Güncelle\n(2) Güncellemekten Vazgeç\n(3) Bilgileri Düzelt");
                        ushort choose = Convert.ToUInt16(Console.ReadLine());

                        switch (choose)
                        {
                            case 1:
                                Console.WriteLine("|************** Eski Kart Bilgileri *************|");
                                Operations.PrintCard(cards[i]);

                                cards[i].Title = updateTitle; 
                                cards[i].Content = updateContent; 
                                cards[i].Size = updateSize; 
                                cards[i].Member = updateMember;

                                Console.WriteLine("|************** Yeni Kart Bilgileri *************|");
                                Operations.PrintCard(cards[i]);
                                Console.WriteLine("Seçilen Kart Güncellendi");
                                break;
                            case 2:
                                Console.WriteLine("Güncelleme iptal edildi.");
                                return;
                            case 3:
                                goto updateRepeat;
                            default:
                                Console.WriteLine("Lütfen doğru bir seçim yapınız!!!");
                                break;
                        }
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Aradığınız başlığa sahip bir kart bulunmamaktadır.Tekrar denemek ister misiniz ?");
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

    public struct Operations
    {
        public static void PrintCard(Card card)
        {
            Console.WriteLine(
                $"|------------------------------------------------|\n" +
                $"Başlık      : {card.Title}\n" +
                $"İçerik      : {card.Content}\n" +
                $"Atanan Kişi : {card.Member.FirstName} {card.Member.LastName}\n" +
                $"Büyüklük    : {card.Size}\n" +
                $"Kart Durumu : {card.Status}\n" +
                $"|------------------------------------------------|"
            );
        }

        public static Sizes SelectSize(ushort size)
        {
            switch (size)
            {
                case 0: return Sizes.XS;
                case 1: return Sizes.S;
                case 2: return Sizes.M;
                case 3: return Sizes.L;
                case 4: return Sizes.XL;
                default: return Sizes.XS;
            }
        }

        public static Status SelectStatus(ushort status)
        {
            switch (status)
            {
                case 0: return Status.TODO;
                case 1: return Status.IN_PROGRESS;
                case 2: return Status.DONE;
                default: return Status.TODO;
            }
        }
    }
}
