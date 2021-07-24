using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Entities
{
    public class RoomAdd
    {
        public int Id { get; set; }
        public int RoomAddNumber { get; set; }
        public string RoomAddText { get; set; }
        public int RoomAddAmount { get; set; }
        public float RoomAddSingle { get; set; }
        public float RoomAddTotal { get; set; }

        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
