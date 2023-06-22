namespace MAS_PROJ.Shared.Models
{
    public class ClientFirm : SystemUser
    {
        public ClientFirm() { }
        public string RegonNumber { get; set; }
        public ClientData ClientData { get; set; }
    }
}
