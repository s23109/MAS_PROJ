using Microsoft.EntityFrameworkCore;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class PersonalData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
