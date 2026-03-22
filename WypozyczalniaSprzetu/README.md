Aplikacja konsolowa napisana w języku C#, umożliwiająca zarządzanie procesem wypożyczania sprzętu.
System pozwala na dodawanie użytkowników oraz sprzętu, realizację wypożyczeń, zwrotów oraz generowanie raportów.

Funkcjonalnosci:
Dodawanie użytkowników (student / pracownik)
Dodawanie sprzętu (np. laptop, kamera, projektor)
Wypożyczanie sprzętu
Zwrot sprzętu (z kontrolą terminu)
oddawanie i odbieranie sprzetu z serwisu
Ograniczenia (np. student max 2 aktywne wypożyczenia)
Generowanie raportu wypożyczeń

Wymagania
.NET SDK (np. .NET 6 / .NET 8)
IDE (np. Rider lub Visual Studio) lub terminal
Uruchomienie z terminala
dotnet run
Uruchomienie w IDE
Otwórz projekt w IDE
Uruchom plik Program.cs (przycisk ▶)

Zastosowano programowanie obiektowe (OOP) — każda encja (np. Uzytkownik, Sprzet, Wypozyczenie) jest osobną klasą.
Wykorzystano dziedziczenie — różne typy sprzętu (np. Laptop, Camera, Projektor) dziedziczą po klasie bazowej.
Logika biznesowa została skupiona w klasie SystemWypozyczen, co upraszcza zarządzanie operacjami.
Wprowadzono walidację danych (np. limit wypożyczeń dla studentów, dostępność sprzętu).
Projekt został podzielony na etapy i rozwijany z użyciem systemu kontroli wersji Git (commity oraz gałęzie robocze).