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
    
    
     public void WypozyczSprzet(int idSprzetu, Uzytkownik uzytkownik, DateTime dataOddania)
    {
        //znajdywanie sprzętu
        var sprzet = listaSprzetu.FirstOrDefault(x => x.Id == idSprzetu);
        

        if (sprzet == null)
        {
            Console.WriteLine("Sprzet nie znaleziono");
            return;
        }
        //Sprawdza dostępność
        if (!sprzet.CzyDostepny(DateTime.Now, dataOddania))
        {
                Console.WriteLine("Sprzet jest Niedostępny!");
                return;
        }
        //Utworzenie wypozyczenia

        int aktywneWypozyczenia = listaWypozyczen.Count(w =>
            w.Wypozyczajacy.Id == uzytkownik.Id &&
            w.FaktycznaDataOddania == null);
        
        if (uzytkownik.TypUzytkownika == TypUzytkownika.student && aktywneWypozyczenia >= 2)
        {
            Console.WriteLine("Student może mieć maksymalnie 2 aktywne wypożyczenia!");
            return;
        }
        
        if (uzytkownik.TypUzytkownika == TypUzytkownika.pracownik && aktywneWypozyczenia >= 5)
        {
            Console.WriteLine("Pracownik może mieć maksymalnie 5 aktywnych wypożyczeń!");
            return;
        }

        


        var wypozyczenie = new Wypozyczenie(
            uzytkownik,
            sprzet,
            DateTime.Now,
            dataOddania
            );
        //Dodanie do listy wypozyczen 
        listaWypozyczen.Add(wypozyczenie);
        sprzet.Wypozyczenia.Add(wypozyczenie);
        
        Console.WriteLine("Wypożyczenie zakończone sukcesem!");
    }

    public void ZwrocSprzet(int idSprzetu)
    {

        var wypozyczenie =
            listaWypozyczen.FirstOrDefault(w => w.WypozyczonySprzet.Id == idSprzetu && w.FaktycznaDataOddania == null);

        if (wypozyczenie == null)
        {
            Console.WriteLine("Nie znaleziono zadnego aktywnego wypozyczenia");
            return;
        }

        wypozyczenie.FaktycznaDataOddania = DateTime.Now;
        int dniSpoznienia = wypozyczenie.ObliczAktualneSpoznienie();
        double oplata =  dniSpoznienia * 100;
        
        wypozyczenie.DodatkowaOplata = oplata;
        Console.WriteLine($"Spóźnienie: {dniSpoznienia} dni");
        Console.WriteLine($"Opłata dodatkowa: {oplata} zł");
        Console.WriteLine("Sprzęt zwrócony do wypożyczalni!");
    }
    
    
    public void OddajDoSerwisu(int idSprzetu, string opis)
    {
        var sprzet = listaSprzetu.FirstOrDefault(x => x.Id == idSprzetu);

        if (sprzet == null)
        {
            Console.WriteLine("Nie znaleziono sprzętu!");
            return;
        }

        if (sprzet.WSerwisie)
        {
            Console.WriteLine("Sprzęt już jest w serwisie!");
            return;
        }

        if (!sprzet.CzyDostepny(DateTime.Now, DateTime.Now))
        {
            Console.WriteLine("Sprzęt jest wypożyczony — nie można oddać do serwisu!");
            return;
        }

        sprzet.WSerwisie = true;

        Console.WriteLine($"Sprzęt oddany do serwisu! Opis: {opis}");
    }
    
    
    public void OdbierzZSerwisu(int idSprzetu)
    {
        var sprzet = listaSprzetu.FirstOrDefault(x => x.Id == idSprzetu);

        if (sprzet == null)
        {
            Console.WriteLine("Nie znaleziono sprzętu");
            return;
        }

        if (!sprzet.WSerwisie)
        {
            Console.WriteLine("Sprzętu nie ma w serwisie!");
            return;
        }

        sprzet.WSerwisie = false;

        Console.WriteLine("Sprzęt odebrany z serwisu!");
    }
    
    
    public void WypozyczeniaUzytkownika(Uzytkownik uzytkownik)
    {
        Console.WriteLine($"Wypożyczenia użytkownika {uzytkownik}:");
        foreach (var wyp in listaWypozyczen)
        {
            if (wyp.Wypozyczajacy.Id == uzytkownik.Id)
            {
                Console.WriteLine(wyp);
            }
        }
    }
    
    public void WyswietlPrzeterminowaneWypozyczenia()
    {
        var przeterminowane = listaWypozyczen
            .Where(w => w.FaktycznaDataOddania == null && w.DataDo < DateTime.Now);

        Console.WriteLine("Przeterminowane wypożyczenia:\n");
        if (!przeterminowane.Any())
        {
            Console.WriteLine("Brak przeterminowanych wypożyczeń.");
            return;
        }
        foreach (var wyp in przeterminowane)
        {
            Console.WriteLine(wyp);
        }
    }
    
    
    public void GenerujRaport()
    {
        int wszystkie = listaSprzetu.Count;

        int wSerwisie = listaSprzetu.Count(s => s.WSerwisie);

        int dostepne = listaSprzetu.Count(s => 
            s.CzyDostepny(DateTime.Now, DateTime.Now));

        int wypozyczone = wszystkie - dostepne - wSerwisie;

        int aktywneWypozyczenia = listaWypozyczen.Count(w => 
            w.FaktycznaDataOddania == null);

        int przeterminowane = listaWypozyczen.Count(w => 
            w.FaktycznaDataOddania == null && w.DataDo < DateTime.Now);

        Console.WriteLine("===== RAPORT WYPOŻYCZALNI =====");
        Console.WriteLine($"Liczba sprzętów: {wszystkie}");
        Console.WriteLine($"Dostępne: {dostepne}");
        Console.WriteLine($"Wypożyczone: {wypozyczone}");
        Console.WriteLine($"W serwisie: {wSerwisie}");
        Console.WriteLine();
        Console.WriteLine($"Aktywne wypożyczenia: {aktywneWypozyczenia}");
        Console.WriteLine($"Przeterminowane: {przeterminowane}");
        Console.WriteLine("================================");
    }

    
    
}