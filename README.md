# GameRentalApp
Aplikacja konsolowa do zarządzania wypożyczalnia gier napisana w języku C# z wykorzystaniem zasad programowania obiektowego.

---

# Opis projektu
GameRentalApp umożliwia:
- przeglądanie dostępnych gier
- wypożyczanie i zwracanie gier
- dodawanie nowych uzytkowników,
- zarządzanie biblioteką gier,
- rozróżnienie ról użytkowników (Administrator / Klient) - administrator może dodawać nowe gry do systemu, natomiast zwykły użytkownik może wypożyczać i zwracać gry.

---

# Struktura projektu
## Klasy
- Game
- PcGame
- ConsoleGame
- User
- GameRentalService
- GameFactory
- Program

## Interfejsy
- IRentable
- IDisplayable

## Enumy
- GameStatus
- UserRole
- RequirementsLevel

---

# Wykorzystane elementy OOP
W projekcie zastosowano:
- klasy i obiekty
- enkapsulację
- dziedziczenie
- polimorfizm
- abstrakcję
- interfejsy
- enumy
- wzorzec projektowy

## Dziedziczenie
Klasy:
- PcGame
- ConsoleGame
  dziedziczą po klasie bazowej 'Game'

## Polimorfizm
Metoda 'DisplayInfo()' została nadpisana w klasach potomnych w celu wyświetlania różnych informacji zależnie od typu gry.

## Abstrakcja
W projekcie zastosowano interfejsy:
- IRentable
- IDisplayable
które definiują wymagane zachowania obiektów.

---

# Wzorzec projektowy - Factory
W projekcie został wykorzystany wzorzec projektowy Factory w klasie 'GameFactory'.
Wzorzec odpowiada za tworzenie różnych typów obiektów gier ('PcGame', 'ConsoleGame') na podstawie przekazanych parameterów, bez konieczności tworzenia obiektów bezpośrednio w klasie 'Program'.

## Zalety zastosowania wzorca
- oddzielenie logiki tworzenie obiektów od logiki programu,
- większa czytelność kodu,
- łatwiejsza rozbudowa aplikacji,
- centralizacja tworzenia obiektów.

---
