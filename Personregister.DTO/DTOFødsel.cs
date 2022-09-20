

namespace Personregister.DTO
{
    public class DTOFødsel
    {
        public long personnummerMor { get; set; }
        public long personnummerFar { get; set; }
        public DTOBarn barn { get; set; }
        public DateTime fødselTid { get; set; }

    }
}
