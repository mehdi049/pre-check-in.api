using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Entities
{
    public class HotelAdmin
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


        public int HotelSettingsId { get; set; }
        public HotelSettings HotelSettings { get; set; }
    }
}
