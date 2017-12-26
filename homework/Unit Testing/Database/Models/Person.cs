using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Person
    {
        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id { get; private set; }
        public string Username { get; private set; }
    }
}
