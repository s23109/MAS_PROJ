using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_PROJ.Shared.Models
{
    public class ClientPerson : SystemUser
    {
        public ClientPerson(){}
        public Client ClientData { get; set; }
        public PersonalData PersonalData { get; set; }

    }
}
