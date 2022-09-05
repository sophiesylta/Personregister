namespace Personregister.WebAPI.Models
{
    public class Fødsel
    {
        public Person mor { get; set; }
        public Person far { get; set; }
        public Person barn { get; set; }
        public DateTime fødselTid { get; set; }

    }
}
