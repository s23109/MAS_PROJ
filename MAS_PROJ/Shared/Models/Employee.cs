using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_PROJ.Shared.Models
{
    public class Employee : SystemUser
    {
        public Employee() { }
        public DateTime HireDate { get; set; }
        public DateTime? FireDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentSalary { get; set; }
        public string? EmployeeNotes { get; set; }
        public PersonalData PersonalData { get; set; }

        //Association - Sale
        public IEnumerable<Sale> PerformedSaleNavigation { get; set; }

    }
}
