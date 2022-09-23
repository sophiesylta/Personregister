using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.Application.Contracts.Repository
{
    public interface IPersonRepository
    {
        List<Person> getAll();
        Person add(Person person);
        Person getPerson(long personnummer);
        Person edit(Person person);

        IQueryable<Person> QueryPerson();
    }
}
