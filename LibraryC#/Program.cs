namespace LibraryC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();

            while (true)
            {
                Console.WriteLine("\n İşlem Menüsü:");
                Console.WriteLine("1 - Kitapları Listele");
                Console.WriteLine("2 - Kitap Ekle");
                Console.WriteLine("3 - Kitap Sil");
                Console.WriteLine("4 - Kitap Güncelle");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        kutuphane.KitaplariListele();
                        break;
                    case "2":
                        kutuphane.KitapEkle();
                        break;
                    case "3":
                        kutuphane.KitapSil();
                        break;
                    case "4":
                        kutuphane.KitapGuncelle();
                        break;
                    case "0":
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                    

                }
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



            public void KitapGuncelle()
            {
                try
                {
                    Console.Write("Güncellemek istediğiniz kitabın adını girin: ");
                    string eskiAd = Console.ReadLine();

                  
                    int index = kitaplar.FindIndex(k => k.Equals(eskiAd, StringComparison.OrdinalIgnoreCase));

                    if (index == -1)
                    {
                        Console.WriteLine($"HATA: '{eskiAd}' adlı kitap listede bulunamadı.");
                        return;
                    }

                    Console.Write("Yeni kitap adını girin: ");
                    string yeniAd = Console.ReadLine();

                    // Yeni ad listede zaten varsa uyarı ver
                    bool kitapZatenVar = kitaplar.Any(k => k.Equals(yeniAd, StringComparison.OrdinalIgnoreCase));
                    if (kitapZatenVar)
                    {
                        Console.WriteLine($"HATA: '{yeniAd}' adlı kitap zaten listede mevcut.");
                        return;
                    }

                    // Güncelleme işlemi
                    kitaplar[index] = yeniAd;
                    Console.WriteLine($"✅ '{eskiAd}' adlı kitap, '{yeniAd}' olarak güncellendi.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Beklenmedik bir hata oluştu: " + ex.Message);
                }
            }
        }
    }
}