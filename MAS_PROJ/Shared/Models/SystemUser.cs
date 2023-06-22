using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_PROJ.Shared.Models
{
    public abstract class SystemUser
    {
        public SystemUser()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }

        //Association - Sale
        public IEnumerable<Sale> OwnSaleNavigation { get; set; }
    }
}
