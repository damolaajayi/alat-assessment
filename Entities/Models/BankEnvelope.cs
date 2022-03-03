using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BankEnvelope
    {
        public string result { get; set; }
        public string bankName { get; set; }
        public string bankCode { get; set; }
        public string errormessage { get; set; }
        public string[] errormessages { get; set; }
        public bool hasError { get; set; }
        public DateTime timeGenerated { get; set; }

    }
}
