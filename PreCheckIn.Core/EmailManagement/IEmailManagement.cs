using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreCheckIn.Core.EmailManagement
{
    public interface IEmailManagement
    {
        bool SendConfirmationEmail(string to, string body);
    }
}
