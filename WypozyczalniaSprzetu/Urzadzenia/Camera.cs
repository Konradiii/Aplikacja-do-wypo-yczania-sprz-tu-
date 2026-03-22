namespace WypozyczalniaSprzetu;

public class Camera : Sprzet
{
    public string Marka { get; set; }
    public bool SzerokoKatnosc { get; set; }
    public string Rozdzielczosc { get; set; }

    public Camera(string marka ,bool szerokoKatnosc, string rozdzielczosc) : base("Camera", "Sprzęt do nagrywania obrazu")
    {
        Marka = marka;
        SzerokoKatnosc = szerokoKatnosc;
        Rozdzielczosc= rozdzielczosc;
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Marka: {Marka} | Szerokokątna: {SzerokoKatnosc} | Rozdzielczość: {Rozdzielczosc}";
    }

}