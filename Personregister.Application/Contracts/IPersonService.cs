using Personregister.Domene;
using Personregister.DTO;
using Optional;

namespace Personregister.Application.Contracts
{

    public interface IDtoPersonService
    {
        public DTOAddPerson add(DTOAddPerson personDTO);
        public DTOEditPerson edit(DTOEditPerson person);

    }

    public interface IDtoGetPersonService
    {
        public List<DTOPerson> getAll();
    }


    public interface IPersonService
    {
        public Person add(Person person);
        public Option<Person> getPerson(long personnummer);
        public Option<Person> getPersonByKallenavn(string kallenavn);
        public Person findOrCreate(long personnummer);
    }
}
