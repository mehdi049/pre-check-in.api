using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public DateTime? ArrivalDate { get; set; }
        [Required]
        public DateTime? DepartureDate { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public int? HotelId { get; set; }
        public DateTime Timestamp { get; set; }

        public Guest BookedBy { get; set; }
        public int GuestId { get; set; }

    }
}
