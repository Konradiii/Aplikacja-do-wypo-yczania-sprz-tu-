namespace WypozyczalniaSprzetu;

public class Projektor : Sprzet
{
    public string Marka { get; set; }
    public string Kolor { get; set; }
    public string ZrodloSwiatla { get; set; }
    
    public Projektor(string marka,string kolor, string zrodloSwiatla) : base(nazwa: "Projektor", podstawoweInformacje: "Projektor przeznaczonny do celów dydaktycznych")
    {
        Marka = marka;
        Kolor = kolor;
        ZrodloSwiatla = zrodloSwiatla;
        
    }
    
    public override string ToString()
    {
        return $"{base.ToString()} | Marka: {Marka} | Kolor: {Kolor} | Źródło światła: {ZrodloSwiatla}";
    }

}