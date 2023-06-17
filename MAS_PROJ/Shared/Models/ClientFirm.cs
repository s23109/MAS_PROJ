using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class ClientFirm:SystemUser
    {
        public ClientFirm() { }

        [Required]
        public string RegonNumber { get; set; }

        public Client ClientData{ get; set; }
    }
}
