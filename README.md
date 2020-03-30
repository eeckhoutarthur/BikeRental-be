# ProjectBikeRentalBE

## Swagger documentatie
Spijtig genoeg is het mij nog niet gelukt om dit voor orders en customers op te stellen. Dit probleem dien ik nog op te lossen.
![](/images/OverzichtEndpoints.PNG)

### GetBikes
![](/images/GetBikes.PNG)

### CreateBike
Na het aanmaken van een fiets komt deze in de lijst van fietsen. Dit kan extra gecontroleerd worden door de GetBikes nog eens te runnen.
De nieuwe fiets staat nu tussen de lijst.
![](/images/CreateBikeDeel1.PNG)
![](/images/CreateBikeDeel2.PNG)
![](/images/CreateBikeDeel3.PNG)

### GetById
![](/images/GetBikeId1.PNG)
![](/images/GetBikeIdDeel1.PNG)

### UpdateBike
![](/images/EditBikeDeel1.PNG)
![](/images/EditBikeDeel2.PNG)
![](/images/EditBikeDeel3.PNG)
Dit kan terug op dezelfde manier gecontroleerd worden, zoals bij de CreateBike.

### DeleteBike
![](/images/DelBikeDeel1.PNG)
![](/images/DelBikeDeel2.PNG)
Dit kan terug op dezelfde manier gecontroleerd worden.

## Klassendiagram
Op dit moment wordt de klasse Brand nog niet gebruikt. Momenteel maak ik gebruik van de enum klasse.

![](/images/klassendiagramGoed.PNG)

### Database
![](/images/klassendiagram.PNG)

## Opstart
Om het project uit te voeren, dien je op de startknop "ProjectBikeRental" te klikken, en niet op "iis Express".
Wanneer het project opgestart is, kunt u zien wat er wordt teruggegeven door de API.
Om de Swagger documentatie raad te plegen wijzigt u in de url "api/Bikes" naar swagger.

Verder heb ik nog een fout met het seeden van de database. De code staat al op zijn plaats, maar wel nog in commentaar.
Dit los ik zo snel mogelijk op.
