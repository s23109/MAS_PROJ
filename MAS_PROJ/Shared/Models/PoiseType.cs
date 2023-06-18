using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class PoiseType
    {
        public int Id { get; set; }
        public PoiseTypes PoiseTypes { get; set; }
    }
    public enum PoiseTypes { Wheels, Tracks }
}
