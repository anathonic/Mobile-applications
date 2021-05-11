using Microsoft.EntityFrameworkCore;
using PeopleAccountApp.DataContracts;
using System;

namespace PeopleAcoountApp.Web
{
    public class PeopleDb : DbContext
    {
        public PeopleDb( DbContextOptions<PeopleDb> options)
            : base(options)
        {
        }


        public DbSet<Person> Person { get; set; }
        public void AddPerson(Person p)
        {
            Person.Add(p);
        }
    }
}
