using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Data.Common
{
    public class Response
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public object Body { get; set; }
    }
}
