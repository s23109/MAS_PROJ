using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }

        public ProductState State { get; set; } = ProductState.InStock;
    }

    public enum ProductState { InStock, Sold, Returned }
}
