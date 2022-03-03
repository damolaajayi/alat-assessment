using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OTPRequestModel
    {
        public string? PhoneNumber { get; set; }
        public OTP Type { get; internal set; }
        public int ExpiryInMinutes { get; internal set; }
    }
}
