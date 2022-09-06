using Personregister.Domene;

namespace Personregister.WebAPI.Models
{
    public interface IFødselRepository
    {
        List<Fødsel> getAll();
        Fødsel add(Fødsel fødsel);
    }
}
