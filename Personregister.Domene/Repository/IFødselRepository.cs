namespace Personregister.Domene.Repository
{
    public interface IFødselRepository
    {
        List<Fødsel> getAll();
        Fødsel add(Fødsel fødsel);
    }
}
