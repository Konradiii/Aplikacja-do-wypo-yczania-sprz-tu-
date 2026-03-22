namespace WypozyczalniaSprzetu;

public class Laptop : Sprzet
{
    public string Marka { get; set; }
    public int IloscRAM { get; set; }

    public Laptop(string marka, int iloscRam) : base(nazwa: "Laptop", podstawoweInformacje: "Laptopy udostępniane przez uczelnie do użytku naukowego")
    {
        Marka = marka;
        IloscRAM = iloscRam;

    }
    
    public override string ToString()
    {
        return $"{base.ToString()} | Marka: {Marka} | RAM: {IloscRAM} GB";
    }

}