using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneCheck_in.Entity
{
    class Person
    {
        [Key]
        public int PersonID { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public IList<Passenger> Passenger { get; set; }
    }
}
