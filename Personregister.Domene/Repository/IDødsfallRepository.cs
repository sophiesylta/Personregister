namespace Personregister.Domene.Repository
{
    public interface IDødsfallRepository
    {
        List<Dødsfall> GetAll();
        Dødsfall add(Dødsfall dødsfall);
    }
}
