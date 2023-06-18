using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class ProductReference
    {
        public ProductReference() {}
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalePrice { get; set; }
        public int IdProduct { get; set; }

        //Association - Part
        public int? IdPart { get; set; }
        
        public Part? PartNavigation { get; set; }

        //Association - Sale
        public int? IdSale { get; set; }
        public Sale SaleNavigation { get; set; }
    }
}
