namespace WypozyczalniaSprzetu;

    public class Uzytkownik
    {
        public int Id { get; }
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public TypUzytkownika TypUzytkownika { get; private set; }
    
        private static int IdCount = 0;
    

        public Uzytkownik(string imie, string nazwisko, TypUzytkownika typUzytkownika)
        {
            Id = IdCount++;
            Imie = imie;
            Nazwisko = nazwisko;
            TypUzytkownika = typUzytkownika;
        }
    
        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }

    }