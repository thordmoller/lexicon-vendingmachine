using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_vendingmachine
{
    internal interface IVending
    {
        // Purchase a product. Returns the product if able to buy, or null if not.
        Product Purchase(int productId, int moneyInserted);

        // Show all Products, returning a list of strings with Id/Name/Cost of each product.
        List<string> ShowAll();

        // Show detailed information of a selected product.
        string Details(int productId);

        // Add money to the money pool.
        void InsertMoney(decimal amount);

        // End the transaction and return the money left as change in a dictionary.
        Dictionary<int, int> EndTransaction();
    }
}
