using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Onboard
    {
        [Column("CustomerId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "PhoneNumber is a required field.")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is a required field.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is a required field.")]
        public string? Password { get; set; }
        public State? State { get; set; }
        
    }

    public class State
    {
        [Required(ErrorMessage = "State of Residence is a required field.")]
        public string? StateofResidence { get; set; }
        [Required(ErrorMessage = "Local Government is a required field.")]
        public string? LGA { get; set; }

    }

}
