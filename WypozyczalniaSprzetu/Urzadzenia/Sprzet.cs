namespace WypozyczalniaSprzetu;


    public class Sprzet
    {
        public int Id { get; }
        public string Nazwa { get; set; }
        public string PodstawoweInformacje  { get; set; }
    
        public bool WSerwisie { get; set; }

        private static int IdCount = 0;
    
        public Sprzet(string nazwa, string podstawoweInformacje)
        {
            Id = IdCount++;
            Nazwa = nazwa;
            PodstawoweInformacje = podstawoweInformacje;
        }
    }