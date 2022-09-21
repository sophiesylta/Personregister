using Personregister.Domene;
using Personregister.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application.Contracts
{
    public interface IPersonService
    {
        public DTOAddPerson add(DTOAddPerson personDTO);
        public List<DTOPerson> getAll();
        public Person getPerson(long personnummer);

    }
}
