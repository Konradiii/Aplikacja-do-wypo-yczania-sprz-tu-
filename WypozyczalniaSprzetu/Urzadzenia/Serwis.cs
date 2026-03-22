namespace WypozyczalniaSprzetu;

public class Serwis
{
    public Sprzet Sprzet { get; set; }
    public DateTime DataSerwisuOd { get; set; }
    public DateTime DataSerwisuDo { get; set; }
    public string Komentarz { get; set; }

    public Serwis(Sprzet sprzet, string komentarz)
    {
        Sprzet=sprzet;
        Komentarz=komentarz;
        DataSerwisuOd=DateTime.Now;
    }
    
}