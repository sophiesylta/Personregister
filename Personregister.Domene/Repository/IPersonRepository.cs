namespace Personregister.Domene.Repository
{
    public interface IPersonRepository
    {
        List<Person> getAll();
        Person add(Person person);
    }
}
