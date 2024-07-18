using System;
using System.Collections.Generic;
using System.Linq;

public class OylamaSistemi
{
    private List<Kullanici> kullanicilar;
    private List<Kategori> kategoriler;

    public OylamaSistemi()
    {
        kullanicilar = new List<Kullanici>();
        kategoriler = new List<Kategori>
        {
            new Kategori("Film Kategorileri"),
            new Kategori("Tech Stack Kategorileri"),
            new Kategori("Spor Kategorileri")
        };
    }

    public void KullaniciKayit(string kullaniciAdi)
    {
        if (!kullanicilar.Any(k => k.KullaniciAdi == kullaniciAdi))
        {
            kullanicilar.Add(new Kullanici(kullaniciAdi));
            Console.WriteLine("Kullanıcı başarıyla kayıt edildi.");
        }
        else
        {
            Console.WriteLine("Bu kullanıcı zaten kayıtlı.");
        }
    }

    public bool KullaniciVarMi(string kullaniciAdi)
    {
        return kullanicilar.Any(k => k.KullaniciAdi == kullaniciAdi);
    }

    public void OyVer(string kullaniciAdi, string kategoriAdi)
    {
        if (KullaniciVarMi(kullaniciAdi))
        {
            var kategori = kategoriler.FirstOrDefault(k => k.Ad == kategoriAdi);
            if (kategori != null)
            {
                kategori.OyVer();
                Console.WriteLine($"{kullaniciAdi} kullanıcısı {kategoriAdi} kategorisine oy verdi.");
            }
            else
            {
                Console.WriteLine("Geçersiz kategori.");
            }
        }
        else
        {
            Console.WriteLine("Kullanıcı kayıtlı değil.");
        }
    }

    public void SonuclariGoster()
    {
        int toplamOy = kategoriler.Sum(k => k.OySayisi);

        Console.WriteLine("\nOylama Sonuçları:");
        foreach (var kategori in kategoriler)
        {
            double yuzde = toplamOy > 0 ? (kategori.OySayisi / (double)toplamOy) * 100 : 0;
            Console.WriteLine($"{kategori.Ad}: {kategori.OySayisi} oy (%{yuzde:F2})");
        }
    }
}
