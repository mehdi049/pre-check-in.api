using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int RateNumber { get; set; }
        public string RateText { get; set; }
        public string RateAmount { get; set; }
        public float RateSingle { get; set; }
        public float RateTotal { get; set; }
        public DateTime RateFrom { get; set; }
        public DateTime RateTo { get; set; }

        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
