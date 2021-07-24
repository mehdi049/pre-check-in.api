using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Entities
{
    public class BookingAdd
    {
        public int Id { get; set; }
        public int BookingAddNumber { get; set; }
        public string BookingAddText { get; set; }
        public int BookingAddAmount { get; set; }
        public float BookingAddSingle { get; set; }
        public float BookingAddTotal { get; set; }

        public Booking Booking { get; set; }
        public int BookingId { get; set; }
    }
}
