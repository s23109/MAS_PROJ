using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class BatteryType
    {
        public BatteryTypes BatteryTypes { get; set; }

    }

    public enum BatteryTypes { NMC, LMO, LFP, NCA }
}
