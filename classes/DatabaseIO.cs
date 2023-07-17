using System;
public static class DatabaseIO {
    public static void SaveToDatabase(List<Entry> input, string path) {
        using (StreamWriter file = new StreamWriter(path)) {
            foreach (Entry item in input) {
                file.WriteLine(item.ToString());
            }
        }
    }
    public static List<Entry> LoadFromDatabase(string path) {
        List<Entry> result = new List<Entry>();
        using (StreamReader file = new StreamReader(path)) {
            string? line;
            while ((line = file.ReadLine()) != null) {
                string[] items = line.Split(',');
                switch(items.Length) {
                    case 6: result.Add(new Entry(items[0],items[1],DateOnly.Parse(items[2]),DateOnly.Parse(items[3]),Convert.ToUInt32(items[4]),
                            ConvertToNullableDouble(items[5]))); break;
                    case 8: result.Add(new AdvancedEntry(items[0],items[1],DateOnly.Parse(items[2]),DateOnly.Parse(items[3]),Convert.ToUInt32(items[4]),
                            ConvertToNullableDouble(items[5]),Convert.ToBoolean(items[6]),ConvertToNullableDouble(items[7]))); break;
                    default: throw new FormatException("Eingelesene Datei in ungültigem Format");
                }
            }
            return result;
        }
    }
    private static double? ConvertToNullableDouble(string input) {
        if (input == "") {
            return null;
        } else {
            return Convert.ToDouble(input,System.Globalization.CultureInfo.InvariantCulture);
        }
    }
 }