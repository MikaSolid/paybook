using System.Collections.Generic;

namespace PayBook.Model
{
    public class Person : Party
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Comment { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}