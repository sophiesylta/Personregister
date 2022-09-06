namespace Personregister.Domene

{
    public class Dødsfall
    {
        public int DødsfallId { get; set; }
        public Person person { get; set; }
        public string dødsårsak { get; set; }
        public DateTime dødsTid { get; set; }
    }
}
