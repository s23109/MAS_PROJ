using Microsoft.EntityFrameworkCore;

namespace MAS_PROJ.Shared.Models
{
    [Owned]
    public class ClientData
    {
        public DateTime RegistrationDate { get; set; }
        public string? ClientNotes { get; set; }
    }
}
