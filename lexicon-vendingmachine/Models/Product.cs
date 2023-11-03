using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_vendingmachine
{

    public abstract class Product
    {
        public string Type { get; }
        public string Name { get; }
        public abstract int Price { get; }
        public string Description { get; }
        public string Ingredients { get; }

        public Product(string name) {
            Type = GetType().Name;
            Name = name;
            Description = "";
            Ingredients = "";
        }
        public Product(string name, string description, string ingredients) : this(name) {
            Description = description;
            Ingredients = ingredients;
        }

        public abstract void Examine();
        public abstract void Use();

        public override string ToString() {
            string s = ", ";    //separator
            return Name + s + Price + " SEK";
        }

        public Product Clone() {
            return (Product)MemberwiseClone();
        }
    }
}
