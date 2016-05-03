using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twitable.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new PersonRepository();
            var list = test.GetAll();
            foreach (var person in list)
            {
                Console.WriteLine("Name: {0}; Birth Year: {1}", person.Name, person.BirthYear);
            }
            Console.ReadLine();
        }
    }
}
