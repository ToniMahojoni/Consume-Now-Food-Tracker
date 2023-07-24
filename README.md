# ConsumeNow - Food Tracker

## Features
### Lebensmittelseite
- Lebensmittelseite, welche anzeigt, was für Lebensmittel sich im Haushalt befinden
    - dazu deren konkreten Bezeichnungen, Mindesthaltbarkeitsdatum, Kaufdatum, Menge, Preis
    - falls man das Lebensmittel offnen kann, ist ebenfalls vermerkt, ob dies bereits geöffnet wurde und wieviel Prozent der Menge noch vorhanden ist

### Einkaufslistenseite
- Einkaufslistenseite, welche die Lebensmittel anzeigt, welche bald eingekauft werden müssen
    - Löschen-Button leert die Einkaufsliste
    - Generieren-Button schaut, welche Lebensmittel knapp werden und setzt diese auf die Einkaufsliste

### Übersichtsseite
- Übersichtsseite, welche alle Kategorien von Lebensmitteln anzeigt
    - dazu deren Lagerort, bei welcher Menge diese zur Einkaufsliste hinzugefügt werden, die Änderung des Haltbarkeitsdatums, wenn diese geöffnet wurden und die konkreten Namen der jeweiligen Produkte einer Kategorie

### Lebensmittel-hinzufügen-Seite
- Lebensmittel-hinzufügen-Seite, welche es ermöglicht neue Lebensmittel hinzuzufügen und bereits eingetragene zu editieren
    - beim Hinzufügen muss aus der Lebensmitteltyp-Checkbox eine Kategorie gewählt werden und der Bestätigen-Button gedrückt werden
    - dann öffnen sich die weiteren Eingabefelder, die mit den jeweiligen Daten des neuen Eintrags befüllt werden können
    - bei der "Haltbarkeit" wird das MhD im Format dd.mm.yyyy verlangt sowie beim "Kaufdatum"
    - beim "Preis" wird das Format e.cc erwartet
    der Speichern-Button schließt das Hinzufügen ab

    - beim Editieren eines bereits eingetragenen Lebensmittels muss aus der Lebensmittelseite die ID herausgefunden werden und in das jeweilige Feld eingetragen werden und der Editieren-Button gedrückt werden
    - dann öffnen sich die weiteren Eingabefelder die bereits die Daten des bisherigen Eintrags beinhalten, wobei diese einfach durch neue Eingaben ersetzt werden können
    - der Speichern-Button schließt das Editieren ab

### Einkauf-hinzufügen-Seite
- Einkauf-hinzufügen-Seite, welche es ermöglicht nach dem Generieren der Einkaufsliste noch zusätzliche Lebensmittel auf die Liste hinzuzufügen
- hinzufügen sollte erst nach dem Generieren geschehen, da sonst die manuellen Einträge überschrieben werden

### Kategorie-hinzufügen-Seite
- Kategorie-hinzufügen-Seite, welche es ermöglicht allgemeine Lebensmitteltypen zur Übersicht-Seite hinzuzufügen, welche dann auch beim Hinzufügen von neuen Lebensmitteln zur Lebensmittelseite als Kategorie gewählt werden können
- "Nachschub bei" ist die Anzahl, für die gilt, dass wenn die noch vorhandene Menge des Lebensmittels diese Anzahl unterschreitet, dieses Lebensmittel beim Generieren auf die Einkaufsliste gesetzt wird
- "Änderung des MhD" ist die Anzahl Tage, wie lang sich das Lebensmittel noch hält, nachdem es geöffnet wurde
- "Produkte" meint die konkreten Lebensmittel (z.B. für Typ Joghurt sind Produkte Vanille-Joghurt, Erdbeer-Joghurt usw.). Für mehrere Produkte müssen diese ohne Leerzeichen durch Semikolon getrennt eingegeben werden

## Hinweis:
Falls die Software in VisualStudio ausgeführt wird, muss in der MainWindow.XAML.cs die VSfilepaths genutzt werden (der Debugger startet aus einem anderen Verzeichnis als die MainWindow-Datei).
Für den Fall, dass die Software gewöhnlich über `dotnet run` im Terminal ausgeführt wird, ist der standardmäßig eingestellte filepath zu verwenden.

## Entwickler von ConsumeNow
ConsumeNow ist das Softwareprojekt des Moduls Softwareentwicklung im Sommersemester 2023 der TU Freiberg als Prüfungsleistung von Toni Sand und Lars Wunderlich.