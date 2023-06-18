using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class CombustionType
    {
        public int Id { get; set; }

        public CombustionTypes CombustionTypes { get; set; }

    }

    public enum CombustionTypes { Diesel, Gasoline }
}
