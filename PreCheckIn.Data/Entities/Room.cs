using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreCheckIn.Data.Entities
{
    public class Room
    {
        public Room()
        {
            Rates = new List<Rate>();
            RoomAdds = new List<RoomAdd>();
            Guests = new List<Guest>();
        }

        public int Id { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        public DateTime? ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }
        [Required]
        public DateTime? DepartureDate { get; set; }
        [Required]
        public int RoomType { get; set; }
        public string RoomTypeText { get; set; }
        public int Package { get; set; }
        public string PackageText { get; set; }
        public int NumberOfGuests { get; set; }
        public string RoomComment { get; set; }

        [Required]
        public List<Rate> Rates { get; set; }
        public List<RoomAdd> RoomAdds { get; set; }
        [Required]
        public List<Guest> Guests { get; set; }

        public Booking Booking { get; set; }
        public int BookingId { get; set; }

    }
}
