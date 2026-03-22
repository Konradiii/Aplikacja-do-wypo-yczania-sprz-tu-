namespace WypozyczalniaSprzetu;


    public class Sprzet
    {
        public int Id { get; }
        public string Nazwa { get; set; }
        public string PodstawoweInformacje  { get; set; }
    
        public bool WSerwisie { get; set; }

        private static int IdCount = 0;
        
        public List<Wypozyczenie> Wypozyczenia { get; set; } = new List<Wypozyczenie>();
    
        public Sprzet(string nazwa, string podstawoweInformacje)
        {
            Id = IdCount++;
            Nazwa = nazwa;
            PodstawoweInformacje = podstawoweInformacje;
        }
        
        public bool CzyDostepny(DateTime od, DateTime doKiedy)
        {
            if (WSerwisie)
                return false;
        
            foreach (var wyp in Wypozyczenia)
            {
                if (od < wyp.DataDo && doKiedy > wyp.DataOd)
                {
                    return false;
                }
            }
            return true;
        }
        
    }