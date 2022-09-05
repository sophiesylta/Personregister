namespace Personregister.WebAPI.Models
{
    public class Person
    {
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public long Personnummer { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

    }
}
