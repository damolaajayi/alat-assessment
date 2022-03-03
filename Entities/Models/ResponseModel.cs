using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ResponseModel
    {
        public string? responseCode { get; set; }
        public string? responseMessage { get; set; }
        public bool isSuccessful { get; set; }
    }
}
