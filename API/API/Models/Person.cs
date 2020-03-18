using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }

    public interface IPersonRepository
    {
        Person Get(int id);
        void Add(Person person);

        List<Person> GetPeople();

    }

    public class FakePersonRepository : IPersonRepository
    {
        private readonly List<Person> people = new List<Person> {

        new Person{Id=1,FirstName="Ali",LastName="Nouri" },
    new Person{Id=2,FirstName="Reza",LastName="Akbari" },
    new Person{Id=3,FirstName="Hamid",LastName="Biglo" },
    new Person{Id=4,FirstName="Shahin",LastName="Norozian" },
};
        public void Add(Person person)
        {
            person.Id = people.Count + 1;
            people.Add(person);
        }

        public Person Get(int id)
        {
           Person Result= people.FirstOrDefault(c => c.Id == id);
            return Result;
        }

        public List<Person> GetPeople()
        {
          return  people;
        }
    }
}
