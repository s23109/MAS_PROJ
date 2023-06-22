using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_PROJ.Shared.Models
{
    public class ProductReference
    {
        public ProductReference() { }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalePrice { get; set; }
        [Key]
        public int IdProduct { get; set; }

        //Association - Part
        public int? IdPart { get; set; }

        public Part? PartNavigation { get; set; }

        //Association - Sale
        public int? IdSale { get; set; }
        public Sale SaleNavigation { get; set; }
    }
}
