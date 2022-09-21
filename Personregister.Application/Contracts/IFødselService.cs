using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.Application.Contracts
{
    public interface IFødselService
    {
        Boolean add(DTOFødsel fødselDTO);

        List<DTOGetFødsel> getAll();    
    }
}