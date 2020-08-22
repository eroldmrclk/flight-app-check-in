using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AirplaneCheck_in.Entity
{
    class Context : DbContext
    {
        public DbSet<Airplane> Airplane { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}

