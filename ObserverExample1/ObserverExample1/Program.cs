internal class Program
{
    private static void Main(string[] args)
    {
        absUrun Kitap = new Urun(50, "Kitap");
        Kitap.TakipList1.Add(new Uye("krdn@gm"));
        Kitap.TakipList1.Add(new Uye("krdn1@gm"));
        Kitap.SetFiyat(45);


    }
}

class absUrun//takip edilen nesne
{
    private int fiyat;
    private string UrunAdi;

    private List<Uye> TakipList = new List<Uye>();

    public absUrun(int fiyat, string urunAdi1)
    {
        SetFiyat(fiyat);
        UrunAdi1 = urunAdi1;
    }

    public void SetFiyat(int value)
    {

        if (fiyat > value)
            this.NotifyUrun(value);
        fiyat = value;

    }

    public int GetFiyat() { return this.fiyat; }


    public string UrunAdi1 { get => UrunAdi; set => UrunAdi = value; }
    internal List<Uye> TakipList1 { get => TakipList; set => TakipList = value; }

    public void NotifyUrun(int yenifiyat)
    {
        foreach (Iuye item in TakipList1)
        {

            item.Update(this, yenifiyat);
        }
    }

}

class Urun : absUrun
{
    public Urun(int fiyat, string urunAdi1) : base(fiyat, urunAdi1)
    {
    }
}

interface Iuye//observer
{
    public void Update(absUrun urun, int YeniFiyat);
}

class Uye : Iuye
{ //concrete observer

    private String Email;

    public Uye(string email)
    {
        Email = email;
    }

    public void Update(absUrun urun, int YeniFiyat)
    {
        Console.WriteLine("{0} ın fiyatı {1} tl oldu  {2} adresine Gönderildi", urun.UrunAdi1, YeniFiyat, getEmail());
    }

    public void getMail(string mail)
    {
        Email = mail;
    }

    public string getEmail() { return Email; }
}