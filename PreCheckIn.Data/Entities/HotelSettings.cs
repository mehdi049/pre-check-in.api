using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Entities
{
    public class HotelSettings
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }

        [Required]
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TripAdvisorLink { get; set; }
        public string BBQFun { get; set; }
        public string PicnicBasket { get; set; }
        public string DiningOptions { get; set; }
        public Blob Logo { get; set; }
    }
}
