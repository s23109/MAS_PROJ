using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS_PROJ.Shared.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }

        [EnumDataType(typeof(BatteryTypes))]
        public ProductState State { get; set; } = ProductState.InStock;
    }

    public enum ProductState { InStock, Sold, Returned }
}
