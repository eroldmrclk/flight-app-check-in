using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneCheck_in.Entity
{
    class Flight
    {
        [Key]
        public int FlightID { get; set; }
        public int AirplaneID { get; set; }
        public string FromFlight { get; set; }
        public string ToFlight { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public float Price { get; set; }
        public int EmptySeat { get; set; }
        public Airplane Airplane { get; set; }
        public IList<Passenger> Passenger { get; set; }
    }
}
