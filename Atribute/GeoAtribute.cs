using System;

namespace Atribute
{
    class GeoAtribute : Attribute
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GeoAtribute(){ }
        public GeoAtribute(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
