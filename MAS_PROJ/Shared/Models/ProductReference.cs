using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class ProductReference
    {
        public ProductReference()
        {
        }
        public decimal? SalePrice { get; set; }

        //Association - Part
        public int? IdPart { get; set; }
        public Part? PartNavigation { get; set; }

        //Association - Sale
        public int IdSale { get; set; }
        public Sale SaleNavigation { get; set; }
    }
}
