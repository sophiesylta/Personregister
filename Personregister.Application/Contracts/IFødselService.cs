using Personregister.Domene;
using Personregister.WebAPI.Models;

namespace Personregister.Application.Contracts
{
    public interface IFødselService
    {
        Fødsel add(DTOFødsel fødselDTO);

        List<Fødsel> getAll();    
    }
}