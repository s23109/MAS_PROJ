using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public enum FuelTypes { NotDefined,
        Combustion, 
        Electric, 
        Other, 
        CombustionElectric, 
        CombustionOther, 
        ElectricOther, 
        CombustionElectricOther
    }

}
