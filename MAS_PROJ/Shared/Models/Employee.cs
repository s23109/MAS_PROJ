using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class Employee : SystemUser
    {
        public Employee()
        {
        }

        public DateOnly HireDate { get; set; }
        public DateOnly? FireDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentSalary { get; set; }
        public string? EmployeeNotes { get; set; }
        public PersonalData PersonalData { get; set; }
    }
}
