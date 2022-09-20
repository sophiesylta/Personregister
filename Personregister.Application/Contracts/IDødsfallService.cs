using Personregister.Domene;
using Personregister.DTO;

namespace Personregister.Application.Contracts
{
    public interface IDødsfallService
    {
        public Dødsfall add(DTODødsfall dødsfallDTO);
        public List<DTOGetDødsfall> GetAll();
    }
}
