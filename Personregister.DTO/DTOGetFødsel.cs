using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.DTO
{
    public class DTOGetFødsel
    {
        public DTOPerson mor { get; set;}
        public DTOPerson far { get; set; }
        public DTOPerson barn { get; set; }
        public string fodselsdato { get; set; }
    }
}
