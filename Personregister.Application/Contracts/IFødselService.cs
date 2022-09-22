using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.Application.Contracts
{
    public interface IFødselService
    {
        DTOFødsel add(DTOFødsel fødselDTO);

        List<DTOGetFødsel> getAll();    
    }
}