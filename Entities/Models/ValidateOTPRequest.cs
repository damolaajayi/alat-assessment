using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ValidateOTPRequest
    {
        public string? Token { get; set; }
        public string? PhoneNumber { get; set; }
        public OTP Type { get; internal set; }
    }
}
