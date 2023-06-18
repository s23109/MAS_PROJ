using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class FuelType
    {
        public int Id { get; set; }

        public FuelTypes FuelTypes { get; set; }


    }

    public enum FuelTypes { Combustion, Electric, Other }
}
