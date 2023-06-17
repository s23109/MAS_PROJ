using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class Part
    {
        public Part()
        {
        }
        public int IdPart { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string PartType { get; set; }
        public string PartCategory { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentPrice { get; set; }
        public static DateOnly OldestReturnDate { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        //Association Recursive - Part 
        public IEnumerable<Part> Alternatives { get; set; }

        //Association - VehiclePart
        public IEnumerable<VehiclePart> VehiclePartNavigation { get; set; }

        //Association - ProductReference
        public IEnumerable<ProductReference> ProductReferenceNavigation { get; set; }
    }
}
