using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSV_reader_2.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("DbConnection")
        { }

        public DbSet<Person> Persons { get; set; }
    }
}