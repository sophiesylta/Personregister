namespace Personregister.WebAPI.Models

{
    public class Dødsfall
    {
        public Person person { get; set; }
        public String dødsårsak { get; set; }
        public DateTime dødsTid { get; set; }
    }
}
