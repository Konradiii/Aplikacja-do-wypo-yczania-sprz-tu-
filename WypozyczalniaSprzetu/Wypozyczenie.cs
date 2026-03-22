namespace WypozyczalniaSprzetu;

public class Wypozyczenie
{
    public Uzytkownik Wypozyczajacy { get; set; }
    public Sprzet WypozyczonySprzet { get; set; }
    public DateTime DataOd { get; set; }
    public DateTime DataDo { get; set; }
    public DateTime? FaktycznaDataOddania { get; set; }
    public double DodatkowaOplata { get; set; }
    private double karaZaDzien = 100;

    public Wypozyczenie(Uzytkownik wypozyczajacy, Sprzet wypozyczonySprzet,  DateTime dataWypozyczenia, 
        DateTime zaplanowanaDataOddania)
    {
        Wypozyczajacy = wypozyczajacy;
        WypozyczonySprzet = wypozyczonySprzet;
        DataOd = dataWypozyczenia;
        DataDo = zaplanowanaDataOddania;
    }
    
    
    public int ObliczAktualneSpoznienie()
    {
        DateTime koniec = FaktycznaDataOddania ?? DateTime.Now;

        if (koniec <= DataDo)
            return 0;

        return (koniec - DataDo).Days;
    }

    public override string ToString()
    {
        return $"{Wypozyczajacy} | {WypozyczonySprzet.Nazwa} | do: {DataDo} | spóźnienie: {ObliczAktualneSpoznienie()} dni";
    }




}