using Personregister.Domene;

namespace Personregister.DTO
{
    public class DTOFødsel
    {
        public long personnummerMor { get; set; }
        public long personnummerFar { get; set; }
        public Person barn { get; set; }
        public DateTime fødselTid { get; set; }

    }
}
