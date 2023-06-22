namespace MAS_PROJ.Shared.Models
{
    public class ClientPerson : SystemUser
    {
        public ClientPerson() { }
        public ClientData ClientData { get; set; }
        public PersonalData PersonalData { get; set; }

    }
}
