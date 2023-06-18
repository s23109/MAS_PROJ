using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class PurposeType
    {
        public PurposeTypes PurposeTypes { get; set; }
    }

    public enum PurposeTypes { Transport, Passenger }
}
