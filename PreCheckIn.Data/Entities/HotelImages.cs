using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PreCheckIn.Data.Entities
{
    public class HotelImages
    {
        public int Id { get; set; }
        public byte[] Logo { get; set; }
        public byte[] SingleRoom { get; set; }
        public byte[] DoubleRoom { get; set; }
    }
}
