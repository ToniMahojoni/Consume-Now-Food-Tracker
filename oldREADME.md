# ProjektSoftwareentwicklungSoSe23
Repository für das Softwareprojekt im Modul Softwareentwicklung im Sommersemester 2023 als Prüfungsleistung von Toni Sand und Lars Wunderlich.

## Grobe Idee
Ein Tracker welcher erfasst, welche Lebensmittel sich im Haushalt befinden und infomiert, wann diese ablaufen / aufgebraucht werden müssen.

## Realistisch umsetzbare Features
- Eintragen von Lebensmitteln mit Haltbarkeitsdatum und eine Benachrichtigungs-Funktion, wenn das MhD bald erreicht ist / bereits erreicht ist...
-> Speichern der Einträge in einer Datenbank
- Markieren, wer welche Lebensmittel aufgebraucht hat
- Möglichkeit einen Kaufpreis mit anzugeben, um die Lebensmittelausgaben im Blick behalten zu können
- Graphische Benutzeroberflächen für eine anschauliche und einfache Bedienung (GUIs werden mit WPF erstellt)
- Automatisches Erstellen einer Einkaufsliste anhand der noch vorrätigen Menge an Lebensmitteln

## Detaillierte Umsetzung
- Jedes gelagerte Produkt gehört einem bestimmten Lebensmitteltyp:
    - Z.B. Apfel, Birne, Banane, Käse, Wurst, Milch, Joghurt ...
    - Jeder Lebensmitteltyp hat konkrete Eigenschaften, z.B. 
        - Lagerort (z.B. Kühlschrank, Tiefkühlfach, Küchenregal, ...)
        - bei welcher noch vorrätigen Menge des Lebensmittels ein automatischer Eintrag auf die Einkaufsliste erfolgen soll
        - ob das Lebensmittel beim Öffnen sofort vollständig aufgebraucht wird, wenn nein:
            - wie sich das Haltbarkeitsdatum nach dem Öffnen verändert
            - für ein konkretes Produkt soll gespeichert werden können:
                - ob es geöffnet ist
                - wie viel des Produktes noch übrig ist
    - Bezeichnungen von Untertypen (z.B. roter Apfel, gelber Apfel,.../Zitronen-Joghurt,Vanille-Joghurt,.../...)
    - Der Nutzer kann Lebensmitteltypen hinzufügen, entfernen und dessen Eigenschaften anpassen
- Speichern der Daten mittels Datenbank, dabei beinhaltet jeder Eintrag folgende Informationen über das Produkt
    - Typ
    - Bezeichnung (kann aus den gespeicherten Bezeichnungen des jeweiligen Typs ausgewählt werden)
    - Haltbarkeitsdatum
    - Datum des Einkaufs
    - Anzahl (mehrere Produkte mit gleichen Eigenschaften sollen in einem Eintrag zusammengefasst werden können)
    - Preis (kann auch leer gelassen werden)
- Anzeigen der Daten mit GUI, dabei soll möglich sein:
    - Ausgeben einer Liste aller gelagerten Produkte, die nach gewünschten Kriterien sortiert ist (z.B. nach Mindesthaltbarkeitsdatum, Alphabet, Datum des Einkaufs, Preis, Typ, Lagerort,...)
    - Übersicht über alle Lebensmitteltypen, für jeden Typ soll
        - eine Liste aller gelagerten Produkte angezeigt werden
        - eine Anpassung der Eigenschaften des Typs möglich sein

## Wunschfeatures, welche möglicherweise zu schwer sind umzusetzen
- Einscannen von Barcodes der Lebensmittel mit Kamera
- Speichern der Datenbank auf einem Server

## Nutzung von Bibliotheken
- Datenbanken
- Einlesen von Barcodes