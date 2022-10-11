using Optional;
using Personregister.Domene;

namespace Personregister.Application.Contracts.Repository
{
    public interface IPersonRepository
    {
        List<Person> getAll();
        Person add(Person person);
        Person getPerson(long personnummer);
        Option<Person> getPersonOptional(long personnummer);
        Option<Person> getPersonByKallenavn(string kallenavn);
        Person edit(Person person);
    }
}
