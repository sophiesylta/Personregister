namespace Personregister.Domene
{
    public class Fødsel
    {
        public int FødselId { get; set; }
        public Person? mor { get; set; }
        public Person? far { get; set; }
        public Person? barn { get; set; }
        public DateTime fødselTid { get; set; }

    }
}
