using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Models
{
  public  interface IRepository
    {

        IEnumerable<Person> People { get; }

        Person GetPerson(int id);
    }
}
