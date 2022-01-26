using System;

namespace Atribute
{
    [GeoAtribute(10,20)]
    class Photo
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Photo(string name) 
        {
            Name = name;
        }
    }
}
