public class Kategori
{
    public string Ad { get; set; }
    public int OySayisi { get; set; }

    public Kategori(string ad)
    {
        Ad = ad;
        OySayisi = 0;
    }

    public void OyVer()
    {
        OySayisi++;
    }
}
