using System;
using System.ComponentModel.DataAnnotations;

namespace PreCheckIn.Data.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        [Required]
        public string GuestNumber { get; set; }
        [Required]
        public string Salutation { get; set; }
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Company { get; set; }
        public DateTime? Birthday { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Iso3 { get; set; }
        public int? IsoCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Passport { get; set; }
        public int GuestType { get; set; }
        public string GuestTypeText { get; set; }
        public bool Business { get; set; }
        public string GuestComment { get; set; }

        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
