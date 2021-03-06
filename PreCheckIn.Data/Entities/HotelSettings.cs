using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Entities
{
    public class HotelSettings
    {
        public HotelSettings()
        {
            HotelAdmin = new HotelAdmin();
            HotelImages = new HotelImages();
        }

        public int Id { get; set; }

        [Required]
        public int Reference { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string TripAdvisorLink { get; set; }
        public string BBQFun { get; set; }
        public string PicnicBasket { get; set; }
        public string DiningOptions { get; set; }

        public int HotelAdminId { get; set; }
        public HotelAdmin HotelAdmin { get; set; }

        public int HotelImagesId { get; set; }
        public HotelImages HotelImages { get; set; }
    }
}
