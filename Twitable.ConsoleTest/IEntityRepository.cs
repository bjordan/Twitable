using System.Collections.Generic;

namespace Twitable.ConsoleTest
{
    public interface IEntityRepository<T>
    {
        List<T> GetAll();
    }

    class PersonRepository : IEntityRepository<Person>
    {
        public List<Person> GetAll()
        {
          return new List<Person>
          {
              new Person{BirthYear = 1964, Name = "Emmanuel"},
              new Person{BirthYear = 1965, Name = "Anne"},
              new Person{BirthYear = 1967, Name = "Andrew"},
              new Person{BirthYear = 1970, Name = "John-Mark"},
              new Person{BirthYear = 1972, Name = "Joseph"},
              new Person{BirthYear = 1976, Name = "Peter"}
         
          };
        }
    }

    internal class Person
    {

        public string Name { get; set; }
        public int BirthYear { get; set; }
    }
}