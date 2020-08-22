using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneCheck_in.Entity
{
    class Passenger
    {
        [Key]
        public int PassengerID { get; set; }
        public int PersonID { get; set; }
        public int FlightID { get; set; }
        public string PNR { get; set; }
        public int SeatNumber { get; set; }
        public Flight Flight { get; set; }
        public Person Person { get; set; }
    }
}
