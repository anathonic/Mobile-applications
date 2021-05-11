using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAccountApp.DataContracts
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }

    }
}
