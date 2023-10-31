using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_vendingmachine
{
    public abstract class Product
    {

        public string? Name { get; protected set; }
        public decimal Price { get; protected set; }

        public abstract void Examine();
        public abstract void Use();
    }
}
