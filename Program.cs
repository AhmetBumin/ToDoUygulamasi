namespace ToDo;

class Program
{
    public static void Menu()
    {
        Console.WriteLine("Lütfen yapmak istediğiniz işlemini seçiniz..");
        Console.WriteLine("(1) Board listelemek \n"
            + "(2) Board' a kart eklemek \n"
            + "(3) Board' dan kart silmek \n"
            + "(4) Kart  taşı \n"
            + "(5) Çıkış");
    }
    static void Main(string[] args)
    {
        Aksiyon aksiyonlar = new();
        bool kontrol = true;
        while (kontrol)
        {
            Console.Clear();
            Menu();
            try
            {
                int secim = Convert.ToInt16(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        aksiyonlar.BoardListeleme();
                        break;
                    case 2:
                        aksiyonlar.KartEklemek();
                        break;
                    case 3:
                        aksiyonlar.KartSilmek();
                        break;
                    case 4:
                        aksiyonlar.KartTasimak();
                        break;
                    case 5:
                        Console.WriteLine("Programdan çıkış yapılıyor...");
                        kontrol = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim yaptınız, lütfen tekrar deneyiniz.. ");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı seçim yaptınız, lütfen tekrar deneyiniz.. ");
            }
            System.Threading.Thread.Sleep(4000);
        }
    }
}