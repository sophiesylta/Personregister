namespace Personregister.Application.Contracts
{
    public interface INavnService
    {
        (string fornavn, string etternavn) getNavn(long personnummer);
    }
}