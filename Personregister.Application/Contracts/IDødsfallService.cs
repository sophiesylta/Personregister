using Personregister.Domene;


namespace Personregister.Application.Contracts
{
    public interface IDødsfallService
    {
        public Dødsfall add(Dødsfall dødsfall);
        public List<Dødsfall> GetAll();
    }
}
