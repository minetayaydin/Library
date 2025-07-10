namespace LibraryC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();
            kutuphane.KitaplariListele();
            kutuphane.KitapSil();
            kutuphane.KitaplariListele(); // kitapsil metodu çalıştı
            kutuphane.KitapEkle();
            kutuphane.KitaplariListele(); //kitapekle metodu çalıştı

        }
    }
    public class Kutuphane
    {
        public List<string> kitaplar = new List<string> { "1984", "Sefiller", "Suç ve Ceza", "Masumiyet Müzesi", "Saatleri Ayarlama Enstitüsü", "Dönüşüm" };

        public void KitaplariListele()
        {
            Console.WriteLine("\n Kitap Listesi:");
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Liste şu anda boş.");
            }
            else
            {
                foreach (var kitap in kitaplar)
                {
                    Console.WriteLine("- " + kitap);
                }
            }
        }


        public void KitapSil()
        {
            try
            {
                Console.Write("Silmek istediğiniz kitabın adını girin: ");
                string silinecekKitap = Console.ReadLine();

                string bulunanKitap = kitaplar
                    .FirstOrDefault(k => k.Equals(silinecekKitap, StringComparison.OrdinalIgnoreCase));

                if (bulunanKitap != null)
                {
                    kitaplar.Remove(bulunanKitap);
                    Console.WriteLine($"'{bulunanKitap}' adlı kitap başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine($"HATA: '{silinecekKitap}' adlı kitap listede bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Beklenmedik bir hata oluştu: " + ex.Message);
            }
        }

        public void KitapEkle()
        {
            try
            {
                Console.Write("Eklemek istediğiniz kitabın adını girin: ");
                string yeniKitap = Console.ReadLine();

                bool kitapZatenVar = kitaplar.Any(k => k.Equals(yeniKitap, StringComparison.OrdinalIgnoreCase));

                if (kitapZatenVar)
                {
                    Console.WriteLine($"HATA: '{yeniKitap}' adlı kitap zaten listede mevcut.");
                }
                else
                {
                    kitaplar.Add(yeniKitap);
                    Console.WriteLine($"✅ '{yeniKitap}' adlı kitap başarıyla eklendi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Beklenmedik bir hata oluştu: " + ex.Message);
            }
        }

    }
}
