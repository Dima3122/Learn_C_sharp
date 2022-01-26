using System;

namespace WorkInBD
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new MyDbContecst())
            {
                var group = new Group()
                {
                    Name = "БИ-2",
                    Year = 195
                };
                context.Groups.Add(group);
                context.SaveChanges();
                Console.WriteLine($"id {group.Id}, name: {group.Name}, Year: {group.Year} ");
            }
        }
    }
}
