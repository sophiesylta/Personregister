using Personregister.Domene;

namespace Personregister.Application.Contracts.Repository
{
    public interface IFødselRepository
    {
        List<Fødsel> getAll();
        Fødsel add(Fødsel fødsel);
    }
}
