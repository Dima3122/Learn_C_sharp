using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var Cars = new List<Car>
            {
                new Car{ name = "Ford", Number = "A00101"},
                new Car{ name = "Lada", Number = "A00102"},
                new Car{ name = "Toyota", Number = "A00105"},
            };
            var Parking = new Parkin();
            foreach (var item in Cars)
            {
                Parking.AddCar(item);
            }
            Console.WriteLine(Parking["A00101"]?.name);
            var num = Console.ReadLine();
            Parking[1] = new Car() { name = "BMW", Number = num };
            Console.WriteLine(Parking[1]);
            foreach (var car in Parking)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }
    }
}
