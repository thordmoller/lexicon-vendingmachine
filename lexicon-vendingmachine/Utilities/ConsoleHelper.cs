using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_vendingmachine
{
    /// <summary>
    /// A class of personal helper methods related to console interaction to be used across multiple console projects to avoid reinventing them every time
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Makes the user select an item from a list and returns the selected index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">message to be displayed to the user related to the operation</param>
        /// <param name="list">The list to select from</param>
        /// <returns>int of the selected index in the list</returns>
        private static int ConsoleListSelector<T>(string message, List<T> list) {
            indexList(list);
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
        public static void indexList<T>(List<T> items) {
            Console.WriteLine();
            for(int i = 0; i < items.Count; i++) {
                T item = items[i];
                Console.WriteLine(i + ". " + item);
            }
            Console.WriteLine();
        }
    }
}
