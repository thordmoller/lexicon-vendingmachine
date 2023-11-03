using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lexicon_vendingmachine
{
    public enum Volume
    {
        cl50 = 50,
        cl33 = 33
    }
    public class Drink:Product
    {
        public override int Price { get; }

        public Volume Volume { get; }


        public Drink(string name, Volume volume) : base(name) {
            Volume = volume;
        }
        public Drink(string name, )

        public override void Examine() {
            throw new NotImplementedException();
        }

        public override void Use() {
            throw new NotImplementedException();
        }
    }
}
