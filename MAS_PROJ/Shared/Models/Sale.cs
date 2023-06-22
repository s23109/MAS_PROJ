using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_PROJ.Shared.Models
{
    public class Sale
    {
        public Sale() { }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSale { get; set; }
        public DateTime DateOfTransaction { get; set; }

        //Association - ProductReference
        public IEnumerable<ProductReference> ProductReferenceNavigation { get; set; }

        //Association - SystemUser
        public int? IdUser { get; set; }
        public SystemUser? BuyerNavigation { get; set; }

        //Association - Employee
        public int? IdEmployee { get; set; }
        [ForeignKey("IdUser")]
        public Employee? EmployeeNavigation { get; set; }


    }
}
