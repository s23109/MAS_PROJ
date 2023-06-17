using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class Client
    {
        [Required]
        public DateOnly RegistrationDate { get; set; }

        public string? ClientNotes { get; set; }; 
    }
}
