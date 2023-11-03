using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lexicon_vendingmachine
{
    /// <summary>
    /// A collection of personal helper methods related to console interaction and list management to be used across multiple console projects to avoid reinventing them every time
    /// </summary>
    public static class ThordsHelper
    {
        private static string jsonPath = "C:\\Users\\thord\\source\\repos\\lexicon-vendingmachine\\lexicon-vendingmachine\\Products.json";

        /// <summary>
        /// Makes the user select an item from a list and returns the selected index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">message to be displayed to the user related to the operation</param>
        /// <param name="list">The list to select from</param>
        /// <returns>int of the selected index in the list</returns>
        private static int ConsoleListSelector<T>(string message, List<T> list) {
            Console.WriteLine(indexList(list));
            int choice;
            do {
                Console.Write(message);
            } while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > list.Count - 1);
            return choice;
        }

        /// <summary>
        /// Displays and puts an index in front of items in a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The list to be displayed of any object type</param>
        public static string indexList<T>(List<T> items) {
            string s = "";
            List<string> stringList = indexStringList(items);
            foreach(string str in stringList)
                s += str;
            return s;
        }

        public static List<string> indexStringList<T>(List<T> items) {
            List<string> s = new List<string>();
            for(int i = 0; i < items.Count; i++) {
                T item = items[i];
                s.Add(i + ". " + item + "\n");
            }

            return s;
        }

        public static List<T> JsonToList<T>() {
            return JsonToList<T>(null);
        }

        public static List<T> JsonToList<T>(JsonConverter<T> converter) {
            List<T> list = new List<T>();

            if(File.Exists(jsonPath)) {
                string json = File.ReadAllText(jsonPath);

                try {
                    var options = new JsonSerializerOptions();
                    if(converter != null) {
                        options.Converters.Add(converter);
                    }

                    list = JsonSerializer.Deserialize<List<T>>(json, options);
                }
                catch(JsonException ex) {
                    // Handle the exception.
                    Console.WriteLine("Error deserializing customer data: " + ex.Message);
                }
                catch(IOException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            else {
                Console.WriteLine("Json file doesn't exist");
            }

            return list;
        }
        public static void SaveListToJson<T>(List<T> list) {


            try {
                var options = new JsonSerializerOptions {
                    WriteIndented = true // Optional: Makes the JSON output human-readable
                };

                string json = JsonSerializer.Serialize(list, options);
                File.WriteAllText(jsonPath, json);
            }
            catch(IOException ex) { Console.WriteLine(ex.Message + "\n" + ex.StackTrace); }
        }
    }
}
