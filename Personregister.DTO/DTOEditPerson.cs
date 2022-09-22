using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.DTO
{
    public class DTOEditPerson
    {
        public long personnummer { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string kallenavn { get; set; }
    }
}
