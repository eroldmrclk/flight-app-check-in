using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneCheck_in.Entity
{
    class Airplane
    {
        [Key]
        public int AirplaneID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        IList<Flight> Flight { get; set; }
    }
}
