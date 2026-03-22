namespace WypozyczalniaSprzetu;

public class SystemWypozyczen
{
    private List<Sprzet> listaSprzetu = new List<Sprzet>();
    private List<Wypozyczenie> listaWypozyczen = new List<Wypozyczenie>();
    
    
    public void DodajSprzet(Sprzet sprzet)
    {
        listaSprzetu.Add(sprzet);
    }
    
    public void WyswietlSprzet()
    {
        foreach (var sprzet in listaSprzetu)
        {
            Console.WriteLine(sprzet);
        }
    }


    public void WyswietlDostepnySprzet()
    {
        Console.WriteLine("Dostępny sprzęt: \n");
        foreach (var sprzet in listaSprzetu)
        {
            if (sprzet.CzyDostepny(DateTime.Now, DateTime.Now))
            {
                Console.WriteLine(sprzet);
            }
        }
    }
    
    
}