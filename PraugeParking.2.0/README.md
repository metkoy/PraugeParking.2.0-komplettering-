# Prague Parking 2.0 – OOP Version

##  Beskrivning
En objektorienterad version av Prague Parking.  
Programmet hanterar bilar och motorcyklar, sparar data i JSON-filer och har ett tydligt textgränssnitt med Spectre.Console.

##  Projektstruktur
- **PragueParking.Core** – Innehåller klasserna Vehicle, Car, MC, ParkingSpot, ParkingGarage.
- **PragueParking.DataAccess** – Hanterar filinläsning/sparning (JSON).
- **PragueParking.UI** – Konsolprogrammet du kör.
- **PragueParking.Tests** – Innehåller enhetstester (MSTest).

##  Så här kör du programmet
1. Öppna solutionen `PragueParking2.0.sln` i Visual Studio.
2. Högerklicka på projektet **PragueParking.UI** → välj *Set as Startup Project*.
3. Tryck **Ctrl + F5** (eller F5) för att starta programmet.
4. Följ instruktionerna i konsolen för att parkera och hämta fordon.

##  Filhantering
- `config.json` innehåller inställningar (antal platser, priser osv).
- `garage.json` sparar alla parkerade fordon.

##  Tester
Det finns två tester i `PragueParking.Tests`:
- Att ett fordon kan parkeras.
- Att ett fordon kan hämtas.

Kör tester via *Test Explorer* i Visual Studio.

##  Krav
- .NET 8.0
- Paket: `Spectre.Console`