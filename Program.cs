using System;

class Program
{
    static void Main(string[] args)
    {
        OylamaSistemi oylamaSistemi = new OylamaSistemi();
        
        while (true)
        {
            Console.WriteLine("\n1. Kayıt Ol\n2. Oy Ver\n3. Sonuçları Göster\n4. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Kullanıcı adı girin: ");
                    string kullaniciAdi = Console.ReadLine();
                    oylamaSistemi.KullaniciKayit(kullaniciAdi);
                    break;
                case "2":
                    Console.Write("Kullanıcı adı girin: ");
                    kullaniciAdi = Console.ReadLine();
                    if (!oylamaSistemi.KullaniciVarMi(kullaniciAdi))
                    {
                        Console.WriteLine("Kullanıcı kayıtlı değil. Lütfen önce kayıt olun.");
                        break;
                    }
                    Console.WriteLine("Kategoriler:");
                    foreach (var kategori in new[] { "Film Kategorileri", "Tech Stack Kategorileri", "Spor Kategorileri" })
                    {
                        Console.WriteLine($"- {kategori}");
                    }
                    Console.Write("Oy vermek istediğiniz kategori: ");
                    string kategoriAdi = Console.ReadLine();
                    oylamaSistemi.OyVer(kullaniciAdi, kategoriAdi);
                    break;
                case "3":
                    oylamaSistemi.SonuclariGoster();
                    break;
                case "4":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
