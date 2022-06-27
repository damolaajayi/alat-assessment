﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    
    public class Result
    {
        public string? bankName { get; set; }
        public string? bankCode { get; set; }
    }

    public class BankEnvelope
    {
        public List<Result> result { get; set; }
        public string? errorMessage { get; set; }
        public string? errorMessages { get; set; }
        public bool hasError { get; set; }
        public DateTime timeGenerated { get; set; }
    }
}
