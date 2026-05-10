ChampionsLeague readme overview

1.sql database extra info
2. sql database procedures


1: Extra info

de sql database heeft enkele speciale design keuzes en hier zal ik ze uitleggen in een Q&A.

Waarom zijn alle zitplaatsen van elk stadium opgeslagen in de database?
Het is waar dat het meer kost op korte termijn. maar over lange termijn is de zitplaatsen opslaan in de producten duurder.

Waarom is er een hometeam en homeClub veld in de database?

Omdat neutrale stadiums bestaan.Elke match heeft een home- en away-team nodig maar niet elk stadium heeft een homeclub nodig.

Hoe ga je om met de business rules?
Grotendeels door proceduren. deze verwerken grotendeels van de data en maakt het dus ook makkelijker voor de regels daar op toe te passen. Ticket regeld wel zijn eigen regels. Match houd ook bij hoeveel plaatsen er zijn in het stadium waar je het aan wilt koppelen en houd je tegen als er niet genoeg plaatsen zijn.
Elke procedure gooit errors als een regel gebroken word en heeft ingebouwde roll-backs voor schade te voorkomen.

Waarom gebruik je proceduren?
Het is minder werk voor de webapplicatie die duurder is op grote schaal.
Het verminderd ook de aanvalsplekken voor slechte handelingen.
En aangezien de proceduren de data all verwerken is het makkelijk om hier ook de regels op toe te passen.

Waarom is er een static en dynamic prijs veld?
Deze velden zijn bedoeld voor prijs veranderingen. Het dynamische veld is voorzien dat het altijd kan verranderd worden zonder problemen. Het statische veld zal altijd hetzelfde blijven. Dit is gedaan omdat bij ticket verkoop vaak de prijzen verranderen. De shoppingCart page is hierop voorzien. Als de prijzen verranderen terijl en persoon andere waarden op hun scherm hebben blijfven deze waarden in het statische veld. Als de pagina opnieuw in laad dan worden de prijzen geupdate en de pagina refreshed automatisch elke 10 minuten.

2: sql database proceduren:

De database heeft enkele proceduren die de applicatie gebruikt om all zijn data te verwerken.
Deze gaan als volgd:

-AddProductToCart.
Deze procedure voegd een product toe aan een gebruiker zijn winkelmandje gebaseerd op hun ID.
Als een gebruiker geen winkelmandje heeft maakt het er 1 aan en hangt hij de nieuwe orderline er aan.
Als het all in het mandje zit dan verhoogd hij de quantiteid van het product.
Deze procedure kijkt ook naar de datum van het product (de font-end doet dit ook maar minder beveiligd).

-FinaliseOrderAndAssignSeats:
Deze procedure kijkt alle waarden in de cart na en gooit errors als de waarden niet geldig zijn.
Als alles ok is dan word de order naar de status van Cart gezet en worden de zitplaatsen toegewezen met de Assignseats procedure gebaseerd op de quantiteid, sectie en club of match (gebaseerd op het producttype).

-Assignseats: Deze procedure vind een open zitplaats en wijst die toe. Als er geen zijn word een error gegooid.
Er zit extra beveiliging op in het geval dat de quantiteid van de sectie veranderd is. Deze procedure houd ook rekening met abonnement plaatsen.

CancelTicketAssignmentById/CancelSubscriptionAssignmentById: dit zijn 2 apparte proceduren die exact hetzelfe concept hebben. Ze nemen de assignment ID checken of de assignment mag geannuleerd worden. Zo ja dan word actief op false gezet. Zo nee dan word een error gegooid.