using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreCheckIn.Data.Entities
{
    public class Booking
    {
        public Booking()
        {
            Rooms = new List<Room>();
            BookingAdds = new List<BookingAdd>();
        }

        public int Id { get; set; }
        [Required]
        public string BookingReference { get; set; }
        [Required]
        public int? HotelId { get; set; }
        public string Comment { get; set; }
        
        public string Token { get; set; }
        public DateTime LastStatusUpdate { get; set; }

        [Required]
        public List<Room> Rooms { get; set; }
        public List<BookingAdd> BookingAdds { get; set; }

        [Required]
        public InvoiceAddress InvoiceAddress { get; set; }
        public int InvoiceAddressId { get; set; }

        public BookingStatus Status { get; set; }
        public int StatusId { get; set; }
        
    }
}
