using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeNow.Database
{
        public static class DatabaseIO
        {
            public static void SaveToDatabase<T>(List<T> input, string path) //Saving into csv file
            {
                using (StreamWriter file = new StreamWriter(path))
                {
                    foreach (T item in input)
                    {
                        if (item != null) file.WriteLine(item.ToString());
                    }
                }
            }
            public static List<Entry> LoadFromEntryDatabase(string path) //Loading from csv file
            {
                List<Entry> result = new List<Entry>();
                foreach (string line in ReadFile(path))
                {
                    result.Add(GenerateEntryInstance(line.Split(',')));
                }
                return result;
            }
            public static List<Type> LoadFromTypeDatabase(string path)
            {
                List<Type> result = new List<Type>();
                foreach (string line in ReadFile(path))
                {
                    result.Add(GenerateTypeInstance(line.Split(','),result));
                }
                return result;
            }
            private static double? ConvertToNullableDouble(string input)
            {
                if (input == "")
                {
                    return null;
                }
                else
                {
                    return Convert.ToDouble(input, System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            private static int? ConvertToNullableInt(string input)
            {
                if (input == "")
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(input);
                }
            }
            private static List<string> ReadFile(string path)
            {
                List<string> result = new List<string>();
                using (StreamReader file = new StreamReader(path))
                {
                    string? line;
                    while ((line = file.ReadLine()) != null)
                    {
                        result.Add(line);
                    }
                }
                return result;
            }
            private static void TestForValidEntryArguments(Entry entry) //prevent nonsensical content form written into Entry list
            {
                //if (entry.BestBeforeDate < DateOnly.FromDateTime(DateTime.Today)) throw new ArgumentException();
                if (entry.Prize != null & entry.Prize <= 0) throw new ArgumentException();
                if (entry.BuyDate > DateOnly.FromDateTime(DateTime.Today)) throw new ArgumentException();
                AdvancedEntry? AdvEntry = entry as AdvancedEntry;
                if (AdvEntry != null)
                {
                    if (AdvEntry.RemainingAmount != null & (AdvEntry.RemainingAmount < 0 | AdvEntry.RemainingAmount > 1)) throw new ArgumentException();
                }
            }
            public static Entry GenerateEntryInstance(string[] input)
            {
                Entry result;
                switch (input.Length)
                {
                    case 6:
                        result = new Entry(input[0], input[1], DateOnly.Parse(input[2]), DateOnly.Parse(input[3]),
                                            Convert.ToUInt32(input[4]), ConvertToNullableDouble(input[5])); break;
                    case 8:
                        result = new AdvancedEntry(input[0], input[1], DateOnly.Parse(input[2]), DateOnly.Parse(input[3]), Convert.ToUInt32(input[4]),
                                            ConvertToNullableDouble(input[5]), Convert.ToBoolean(input[6]), ConvertToNullableDouble(input[7])); break;
                    default: throw new FormatException();
                }
                TestForValidEntryArguments(result);
                return result;

            }
            private static void TestForValidTypeArguments(Type type,List<Type> types)  //prevent nonsensical content form written into Type list
            {
                if(type.Name == "") throw new ArgumentException();
                if(type.BestBeforeDateChange < 0) throw new ArgumentException();
                if(type.WhenToAddToShoppingList < 0) throw new ArgumentException();
                if(type.Subnames.Length == 1 & type.Subnames[0] == "") throw new ArgumentException(); 
                bool TypeNameAlreadyExists = false;
                try {
                    Type existing_type = ManageDatabase.SelectType(types,type.Name);
                    TypeNameAlreadyExists = true;
                } catch {}
                if(TypeNameAlreadyExists) throw new ArgumentException();
            }
            public static Type GenerateTypeInstance(string[] input,List<Type> types)
            {
                if (input.Length == 6)
                {
                    Type result = new Type(input[0], input[1], ConvertToNullableDouble(input[2]), ConvertToNullableInt(input[3]), input[4].Split(';'), Convert.ToUInt32(input[5]));
                    TestForValidTypeArguments(result,types);
                    return result;
                }
                else
                {
                    throw new FormatException();
                }
            }
        }
}
