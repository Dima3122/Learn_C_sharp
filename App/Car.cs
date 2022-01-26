using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Car
    {
        public string name { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return name + " " +Number;
        }
    }
}
