# Betriebsmittelverwaltung

AWE Projekt

Programmier-Projekt „Betriebsmittelverwaltung“

Hintergrund & Zielsetzung Auf Baustellen werden neben Großgeräten wie Kranen und Hubbühnen auch verschiedene Kleingeräte und Werkzeuge eingesetzt. Für Bauunternehmen ist es wichtig, jederzeit einen Überblick darüber zu behalten, welches dieser Geräte sich zu welchem Zeitpunkt im Lager oder auf einer bestimmten Baustelle befindet. Das Unternehmen WueBau GmbH hat aktuell noch keine passende IT-Lösung, um das eigene Lager sowie die eingesetzten Ressourcen digital abzubilden. Der Geschäftsführer der WueBau GmbH möchte daher eine entsprechende Webanwendung entwickeln lassen, welche wiederum auf einer relationalen Datenbank aufbaut.

Zur Entwicklung eines Prototyps sollen .NET-Technologien eingesetzt werden. Verwenden Sie dazu die in der Lehrveranstaltung vorgestellten Konzepte von C#, ASP.NET MVC, HTML, CSS und JavaScript. Das Projekt soll mehrere Anforderungen erfüllen, die im Folgenden in der Art eines Lastenhefts genauer beschrieben werden. Die konkrete Umsetzung wie auch die logische Ausarbeitung der Funktionalitäten der Webanwendung bleibt Ihnen überlassen.

Lastenheft

• In der Baustellenverwaltung wird die Liste der aktuell laufenden Bauprojekte gepflegt. Bauprojekte werden jeweils über eine ID, einen Kurznamen und einen Beschreibungstext in der Datenbank abgebildet. Jedem Bauprojekt ist ein Baustellenleiter zugeordnet, der als User in der Datenbank registriert sein muss.

• In der Bestandsverwaltung können Ressourcen (Maschinen, Werkzeuge usw.) angelegt und gepflegt werden. Zu jeder Ressource werden Informationen wie der Typ, das Kaufdatum oder notwendige Wartungsintervalle gespeichert.

• Baustellenleiter haben die Möglichkeit, zu einem Bauprojekte Aufträge zur Bereitstellung einer zusätzlichen Ressource anzulegen. Zu diesem Zweck kann aus der Liste der Ressourcentypen der passende Typ spezifiziert werden. Diese Aufträge sehen Lageristen in einer zentralen Auftragsverwaltung und können dort jeweils eine passende Ressource auswählen, die gerade nicht auf einem Bauprojekt eingesetzt wird. Wenn eine passende Ressource gefunden wird, erfolgt ein Check-out, d.h., die Ressource wird im System dem Bauprojekt zugeordnet.

• Wenn eine Ressource nicht mehr benötigt wird, kann der Baustellenleiter diese aus der Liste aller dem Bauprojekt zugeordneten Ressourcen auswählen und eine Retoure anlegen. Diese kann vom Lageristen in der Retourenverwaltung eingesehen und bestätigt werden. Die Bestätigung entspricht einem Check-in, d.h., die Ressource wird wieder dem Lager zugeordnet.

• Im System existiert eine einfache Nutzerverwaltung, in der Nutzer angelegt und verwaltet werden können. Zugriff hat nur der Administrator der Anwendung. Nutzer können darüber hinaus den Rollen „Lagerist“ sowie „Bauleiter“ zugeordnet werden.• Zu jeder Ressource kann in der Bestandsverwaltung eingesehen werden, wann Check-Ins bzw. Check-outs in der Vergangenheit erfolgt sind. Zu jeder Ressource wird außerdem die Auslastungsquote berechnet, d.h., der Anteil der Zeit seit Anschaffung der Ressource, während der die Ressource nicht im Lager war. Das entwickelte Tool muss aus Komplexitätsgründen keine Personalplanung abbilden können.
