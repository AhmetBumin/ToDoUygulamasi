using System;
namespace ToDo
{
	public class Aksiyon
	{
		List<Person> kisiler = new();
        List<Card> cardsinprogress = new();
        List<Card> cardsintodo = new();
        List<Card> cardsindone = new();
        

        public Aksiyon()
		{
            kisiler.Add(new Person("Ahmet", 3));
            kisiler.Add(new Person("Bumin", 2));
            kisiler.Add(new Person("Korhan", 7));
            kisiler.Add(new Person("Kaan", 9));
            kisiler.Add(new Person("Tarik", 10));
            
        }
        public void BoardListeleme()
        {
            Console.WriteLine("TODO Line \n" + "*****");
            if (cardsintodo.Count>0)
            {
                for (int i = 0; i < cardsintodo.Count; i++)
                {
                    Console.WriteLine("Başlık: " + cardsintodo[i].baslik);
                    Console.WriteLine("İçerik: " + cardsintodo[i].icerik);
                    Console.WriteLine("Atanan Kişi: " + cardsintodo[i].kisi);
                    Console.WriteLine("Büyüklük: " + cardsintodo[i].buyukluk);
                    Console.WriteLine(" ");
                }
            }
            if (cardsintodo.Count==0)
            {
                Console.WriteLine("BOŞ\n");
            }
            Console.WriteLine("IN PROGRESS Line \n" + "*****");
            if (cardsinprogress.Count > 0)
            {
                for (int i = 0; i < cardsinprogress.Count; i++)
                {
                    Console.WriteLine("Başlık: " + cardsinprogress[i].baslik);
                    Console.WriteLine("İçerik: " + cardsinprogress[i].icerik);
                    Console.WriteLine("Atanan Kişi: " + cardsinprogress[i].kisi);
                    Console.WriteLine("Büyüklük: " + cardsinprogress[i].buyukluk);
                    Console.WriteLine(" ");
                }
            }
            if (cardsinprogress.Count == 0)
            {
                Console.WriteLine("BOŞ\n");
            }
            Console.WriteLine("DONE Line \n" + "*****");
            if (cardsindone.Count > 0)
            {
                for (int i = 0; i < cardsindone.Count; i++)
                {
                    Console.WriteLine("Başlık: " + cardsindone[i].baslik);
                    Console.WriteLine("İçerik: " + cardsindone[i].icerik);
                    Console.WriteLine("Atanan Kişi: " + cardsindone[i].kisi);
                    Console.WriteLine("Büyüklük: " + cardsindone[i].buyukluk);
                    Console.WriteLine(" ");
                }
            }
            if (cardsindone.Count == 0)
            {
                Console.WriteLine("BOŞ");
            }
        }
        public void KartEklemek()
        {
            Card kartlar = new();
            bayrak1:
            Console.Write("Başlık giriniz: ");
            string baslik = Console.ReadLine();
            if (!string.IsNullOrEmpty(baslik))
            {
                kartlar.baslik=baslik;
            }
            else
            {
                Console.WriteLine("Lütfen boş bırakmayınız, bir değer giriniz..");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                goto bayrak1;
            }
            bayrak2:
            Console.Write("İçerik giriniz: ");
            string icerik = Console.ReadLine();
            if (!string.IsNullOrEmpty(icerik))
            {
                kartlar.icerik = icerik;
            }
            else
            {
                Console.WriteLine("Lütfen boş bırakmayınız, bir değer giriniz..");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                goto bayrak2;
            }
            bayrak3:
            Console.Write("Büyüklük seçiniz: XS(1), S(2), M(3), L(4), XL(5): ");
            bool parseSuccess = Enum.TryParse(Console.ReadLine(), out kartlar.buyukluk);

            if (!parseSuccess)
            {
                Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                goto bayrak3;
            }
            bayrak4:
            Console.WriteLine("Kişi seçiniz (ID değerini girin)");
            for (int i = 0; i < kisiler.Count; i++)
            {
                Console.WriteLine("Kişi:{0}, ID:{1}",kisiler[i].isim, kisiler[i].ID);
            }
            try
            {
                int kisi = Convert.ToInt16(Console.ReadLine());
                for (int i = 0; i < kisiler.Count; i++)
                {
                    if (kisiler[i].ID==kisi)
                    {
                        kartlar.kisi = kisiler[i].isim;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                goto bayrak4;
            }
            Console.Clear();
            bayrak5:
            Console.WriteLine("Kartı hangi board' a eklemek istiyorsunuz?");
            Console.Write("(1) ToDo, (2) In Progress, (3) Done  ");
            try
            {
                int secim = Convert.ToInt16(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        cardsintodo.Add(kartlar);
                        break;
                    case 2:
                        cardsinprogress.Add(kartlar);
                        break;
                    case 3:
                        cardsindone.Add(kartlar);
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        goto bayrak5;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                goto bayrak5;
            }
        }
        public void KartSilmek()
        {
            bayrak6:
            Console.Clear();
            Console.Write("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
            string cevapBaslik = Console.ReadLine();
            Console.WriteLine(" ");
          
            bool kartBulundu = true;
            for (int i = 0; i < cardsintodo.Count; i++)
            {
                if (cardsintodo[i].baslik==cevapBaslik)
                {   
                    Console.WriteLine("Aşağıdaki kart silenecektir");
                    Console.WriteLine("Başlık: " + cardsintodo[i].baslik);
                    Console.WriteLine("İçerik: " + cardsintodo[i].icerik);
                    Console.WriteLine("Atanan Kişi: " + cardsintodo[i].kisi);
                    Console.WriteLine("Büyüklük: " + cardsintodo[i].buyukluk);
                    Console.WriteLine(" ");
                    cardsintodo.RemoveAt(i);
                    kartBulundu = false;
                }
            }
            for (int i = 0; i <cardsinprogress.Count; i++)
            {
                if (cardsinprogress[i].baslik == cevapBaslik)
                {
                    Console.WriteLine("Aşağıdaki kart silenecektir");
                    Console.WriteLine("Başlık: " + cardsinprogress[i].baslik);
                    Console.WriteLine("İçerik: " + cardsinprogress[i].icerik);
                    Console.WriteLine("Atanan Kişi: " + cardsinprogress[i].kisi);
                    Console.WriteLine("Büyüklük: " + cardsinprogress[i].buyukluk);
                    Console.WriteLine(" ");
                    cardsinprogress.RemoveAt(i);
                    kartBulundu = false;
                }
            }
            for (int i = 0; i < cardsindone.Count; i++)
            {
                if (cardsindone[i].baslik == cevapBaslik)
                {
                    Console.WriteLine("Aşağıdaki kart silenecektir");
                    Console.WriteLine("Başlık: " + cardsindone[i].baslik);
                    Console.WriteLine("İçerik: " + cardsindone[i].icerik);
                    Console.WriteLine("Atanan Kişi: " + cardsindone[i].kisi);
                    Console.WriteLine("Büyüklük: " + cardsindone[i].buyukluk);
                    Console.WriteLine(" ");
                    cardsindone.RemoveAt(i);
                    kartBulundu = false;
                }
            }
            if (kartBulundu)
            {
                bayrak7:
                Console.Clear();
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                try
                {
                    int cevap = Convert.ToInt16(Console.ReadLine());
                    if (cevap==1)
                    {
                        Console.Clear();
                        Console.WriteLine("Silme işleminden çıkılıyor...");
                    }
                    else if (cevap==2)
                    {
                        Console.WriteLine("Silme menüsüne tekrar aktarılıyorsunuz..");
                        System.Threading.Thread.Sleep(2000);
                        goto bayrak6;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                        System.Threading.Thread.Sleep(2000);
                        goto bayrak7;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                    System.Threading.Thread.Sleep(2000);
                    goto bayrak7;
                }
            }
        }
        public void KartTasimak()
        {
            Console.Clear();
            Console.Write("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
            string cevapBaslik = Console.ReadLine();
            Console.WriteLine(" ");

            bool kartBulundu = true;
            for (int i = 0; i < cardsintodo.Count; i++)
            {
                if (cardsintodo[i].baslik == cevapBaslik)
                {
                    Console.WriteLine("Aşağıdaki kart taşınacaktır");
                    Console.WriteLine("ToDo Line");
                    Console.WriteLine("Başlık: " + cardsintodo[i].baslik);
                    Console.WriteLine("İçerik: " + cardsintodo[i].icerik);
                    Console.WriteLine("Atanan Kişi: " + cardsintodo[i].kisi);
                    Console.WriteLine("Büyüklük: " + cardsintodo[i].buyukluk);
                    Console.WriteLine(" ");
                    System.Threading.Thread.Sleep(2000);

                    bayrak9:
                    Console.WriteLine("(1)Bulunan kartı taşıma işlemine devamı için\n(2) diğer kartlara bakmak için");
                    string secim = Console.ReadLine();
                    Console.Clear();

                    if (secim=="1")
                    {
                        bayrak10:
                        Console.Clear();
                        Console.WriteLine("Kartı nereye taşımak istiyorsunuz?\n(1) In Progress Line\n(2) Done Line");
                        string cevap = Console.ReadLine();
                        if (cevap == "1")
                        {
                            cardsinprogress.Add(cardsintodo[i]);
                            cardsintodo.RemoveAt(i);
                            kartBulundu = false;
                            break;
                        }
                        if (cevap == "2")
                        {
                            cardsindone.Add(cardsintodo[i]);
                            cardsintodo.RemoveAt(i);
                            kartBulundu = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                            System.Threading.Thread.Sleep(2000);
                            goto bayrak10;
                        }
                    }
                    if (secim=="2")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                        System.Threading.Thread.Sleep(2000);
                        goto bayrak9;
                    }
                }
            }
            if (kartBulundu) //in progress listesi kontrolü
            {
                for (int i = 0; i < cardsinprogress.Count; i++)
                {
                    if (cardsinprogress[i].baslik == cevapBaslik)
                    {
                        Console.WriteLine("Aşağıdaki kart taşınacaktır");
                        Console.WriteLine("ToDo Line");
                        Console.WriteLine("Başlık: " + cardsinprogress[i].baslik);
                        Console.WriteLine("İçerik: " + cardsinprogress[i].icerik);
                        Console.WriteLine("Atanan Kişi: " + cardsinprogress[i].kisi);
                        Console.WriteLine("Büyüklük: " + cardsinprogress[i].buyukluk);
                        Console.WriteLine(" ");
                        System.Threading.Thread.Sleep(2000);

                    bayrak9:
                        Console.WriteLine("(1)Bulunan kartı taşıma işlemine devamı için\n(2) diğer kartlara bakmak için");
                        string secim = Console.ReadLine();
                        Console.Clear();
                        if (secim == "1")
                        {
                        bayrak10:
                            Console.Clear();
                            Console.WriteLine("Kartı nereye taşımak istiyorsunuz?\n(1) ToDo Line\n(2) Done Line");
                            string cevap = Console.ReadLine();
                            if (cevap == "1")
                            {
                                cardsintodo.Add(cardsinprogress[i]);
                                cardsinprogress.RemoveAt(i);
                                kartBulundu = false;
                                break;
                            }
                            if (cevap == "2")
                            {
                                cardsindone.Add(cardsinprogress[i]);
                                cardsinprogress.RemoveAt(i);
                                kartBulundu = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                                System.Threading.Thread.Sleep(2000);
                                goto bayrak10;
                            }
                        }
                        if (secim == "2")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                            System.Threading.Thread.Sleep(2000);
                            goto bayrak9;
                        }
                    }
                }
            }
            if (kartBulundu) //done listesi kontrolü
            {
                for (int i = 0; i < cardsindone.Count; i++)
                {
                    if (cardsindone[i].baslik == cevapBaslik)
                    {
                        Console.WriteLine("Aşağıdaki kart taşınacaktır");
                        Console.WriteLine("ToDo Line");
                        Console.WriteLine("Başlık: " + cardsindone[i].baslik);
                        Console.WriteLine("İçerik: " + cardsindone[i].icerik);
                        Console.WriteLine("Atanan Kişi: " + cardsindone[i].kisi);
                        Console.WriteLine("Büyüklük: " + cardsindone[i].buyukluk);
                        Console.WriteLine(" ");
                        System.Threading.Thread.Sleep(2000);

                    bayrak9:

                        Console.WriteLine("(1)Bulunan kartı taşıma işlemine devamı için\n(2) diğer kartlara bakmak için");
                        string secim = Console.ReadLine();
                        Console.Clear();
                        if (secim == "1")
                        {
                        bayrak10:
                            Console.Clear();
                            Console.WriteLine("Kartı nereye taşımak istiyorsunuz?\n(1) ToDo Line\n(2) In Progress Line");
                            string cevap = Console.ReadLine();
                            if (cevap == "1")
                            {
                                cardsintodo.Add(cardsindone[i]);
                                cardsindone.RemoveAt(i);
                                kartBulundu = false;
                                break;
                            }
                            if (cevap == "2")
                            {
                                cardsinprogress.Add(cardsindone[i]);
                                cardsindone.RemoveAt(i);
                                kartBulundu = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                                System.Threading.Thread.Sleep(2000);
                                goto bayrak10;
                            }
                        }
                        if (secim == "2")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim yaptınız lütfen tekrar deneyiniz..");
                            System.Threading.Thread.Sleep(2000);
                            goto bayrak9;
                        }
                    }
                }
            }
        }
    }
}