namespace WypozyczalniaSprzetu;

public class SystemWypozyczen
{
    private List<Sprzet> listaSprzetu = new List<Sprzet>();
    private List<Wypozyczenie> listaWypozyczen = new List<Wypozyczenie>();
    
    
    public void DodajSprzet(Sprzet sprzet)
    {
        listaSprzetu.Add(sprzet);
    }
    
    
}