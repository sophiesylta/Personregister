using Personregister.Domene;
using Personregister.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personregister.Application.Contracts
{

    public interface IDtoPersonService
    {
        public DTOAddPerson add(DTOAddPerson personDTO);
 
        public List<DTOPerson> getAll();
        public DTOEditPerson edit(DTOEditPerson person);

    }


    public interface IPersonService
    {
        public Person add(Person person);
        public Person getPerson(long personnummer);
    }
}
