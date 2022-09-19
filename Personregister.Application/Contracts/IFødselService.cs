using Personregister.Domene;

namespace Personregister.Application.Contracts
{
    public interface IFødselService
    {
        Fødsel add(Fødsel fødsel);

        List<Fødsel> getAll();    
    }
}