using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexicon_vendingmachine.Models
{
    public class CandyBar:Product
    {
        public CandyBar(string name) : base(name) {
        }

        public override int Price => throw new NotImplementedException();



        public override void Examine() {
            throw new NotImplementedException();
        }

        public override void Use() {
            throw new NotImplementedException();
        }
    }
}
