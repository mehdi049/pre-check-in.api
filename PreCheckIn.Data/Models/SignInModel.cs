using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Models
{
    public class SignInModel
    {
        [Required]
        public string Reference { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime? ArrivalDate { get; set; }
        [Required]
        public DateTime? DepartureDate { get; set; }
    }
}
