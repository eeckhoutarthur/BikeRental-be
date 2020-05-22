# ProjectBikeRentalBE

## Swagger documentatie
## BikesController
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

## AccountController
![](/images/overzichtEndpointsAccount.png)

### Login
![](/images/inloggen1.png)

Na het klikken op "execute" krijgen wij het volgende resultaat.

![](/images/inloggen2.png)

Het inloggen is gelukt. De API geeft een jwt token mee die alle informatie zal bevatten. Uit dit token kunnen wij in de frontend
alle informatie halen. Sommige van deze endpoints zijn beveiligt, en kunnen alleen maar uitgevoerd worden wanneer de gebruiker is ingelogd. Om dit te kunnen testen klikt u bovenaan op de webpagina op de knop "Authorize". Vervolgens vult u in het veldje Bearer en het jwt token dat de server teruggaf bij het inloggen of registreren.

### Register
![](/images/registreren1.png)

Om een gebruiker succesvol te registreren vult u alle velden in. Zorg ervoor dat het emailadres nog niet gebruikt is en dat het passwoord bestaat uit minstens één grote en kleine letter, minstens één cijfer en minstens één speciaal karakter.

![](/images/registreren2.png)

Opnieuw krijgen wij van de API een jwt token terug.

### Controleren op een beschikbaar emailadres
De API zal een true teruggeven wanneer het emailadres nog niet bestaat.

![](/images/ControleBeschikbaarAccount.png)

In dit geval retourneert de API een false omdat dit account al bestaat. Wij hebben dit zonet aangemaakt bij het registreren.




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
