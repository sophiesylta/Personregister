using Personregister.Domene;

namespace Personregister.WebAPI.Models
{
    public class DTOFødsel
    {
        public long personnummerMor { get; set; }
        public long personnummerFar { get; set; }
        public Person barn { get; set; }
        public DateTime fødselTid { get; set; }

    }
}
