using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.Application.Contracts
{
    public interface IFødselService
    {
        Fødsel add(DTOFødsel fødselDTO);

        List<Fødsel> getAll();    
    }
}