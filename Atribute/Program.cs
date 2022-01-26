using System;
using System.Reflection;

namespace Atribute
{
    class Program
    {
        static void Main(string[] args)
        {
            var Photo = new Photo("Hello.png")
            {
                Path = "C/"
            };
            var type = typeof(Photo);
            var attribytes = type.GetCustomAttributes();
            Console.WriteLine();
        }
    }
}
