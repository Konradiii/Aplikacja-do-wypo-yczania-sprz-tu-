using WypozyczalniaSprzetu;


SystemWypozyczen system = new SystemWypozyczen();

Uzytkownik u1 = new Uzytkownik("Konrad", "XDDD", TypUzytkownika.student);
Uzytkownik u2 = new Uzytkownik("Kasia", "ASNDFOAS", TypUzytkownika.student);
Uzytkownik u3 = new Uzytkownik("Milosz", "Kowalski", TypUzytkownika.pracownik);
Uzytkownik u4 = new Uzytkownik("Tomek", "Swistak", TypUzytkownika.pracownik);
Uzytkownik u5 = new Uzytkownik("Ala", "Brtok", TypUzytkownika.student);
Uzytkownik u6 = new Uzytkownik("Ola", "Cqsahfe", TypUzytkownika.pracownik);


system.DodajSprzet(new Camera("Nikon", true, "4K"));
system.DodajSprzet(new Laptop("Dell", 16));
system.DodajSprzet(new Laptop("Lenovo", 32));
system.DodajSprzet(new Laptop("AsusRog", 32));
system.DodajSprzet(new Projektor("Phantom","Czarny", "Laser"));
system.DodajSprzet(new Projektor("Phantom","Bialy", "Ze slonca"));

system.WypozyczSprzet(3,u2,new DateTime(2026,4,19));


Console.WriteLine("====================== Próba wypozyczenia niedostepnego sprzetu ======================"); 
system.WypozyczSprzet(3,u4,new DateTime(2026,3,26));


Console.WriteLine("====================== Zwrot sprzetu w terminie ======================\n"); 
system.WypozyczSprzet(5,u2,new DateTime(2030,5,19));
system.ZwrocSprzet(5);


Console.WriteLine("====================== Zwrot sprzetu poza terminiem ======================\n"); 
system.WypozyczSprzet(1,u2,new DateTime(2025,5,19));
system.ZwrocSprzet(1);


Console.WriteLine("====================== Wygenerowanie raportu ======================\n"); 
system.GenerujRaport();

Console.WriteLine("===== Test limitu studenta =====");

system.WypozyczSprzet(1, u1, DateTime.Now.AddDays(5));
system.WypozyczSprzet(2, u1, DateTime.Now.AddDays(5));

// to powinno NIE przejść
system.WypozyczSprzet(4, u1, DateTime.Now.AddDays(5));

Console.WriteLine("===== Zwrot niewypozyczonego sprzetu =====");

system.ZwrocSprzet(10); // nie istnieje lub nie wypożyczony


