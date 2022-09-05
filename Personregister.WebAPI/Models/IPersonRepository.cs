namespace Personregister.WebAPI.Models
{
    public interface IPersonRepository
    {
        List<Person> getAll();
        Person add(Person person);
    }
}
