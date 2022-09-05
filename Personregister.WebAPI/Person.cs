namespace Personregister.WebAPI
{
    public class Person
    {
        public String Fornavn { get; set; }
        public String Etternavn { get; set; }

        public DateTime CreateAt { get; set; }=DateTime.Now;

    }
}
