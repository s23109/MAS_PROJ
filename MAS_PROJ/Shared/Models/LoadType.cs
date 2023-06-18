using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class LoadType
    {
        public int Id { get; set; }
        public LoadTypes LoadTypes { get; set; }
    }

    public enum LoadTypes { Liquid, Gas, Solid }
}
