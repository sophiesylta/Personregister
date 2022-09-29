using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.Application.Contracts.Repository
{
    public interface IPersonRepository
    {
        List<Person> getAll();
        Person add(Person person);
        Person getPerson(long personnummer);
        Person getPersonByKallenavn(string kallenavn);
        Person edit(Person person);
    }
}
