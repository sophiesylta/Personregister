namespace Personregister.WebAPI.Models
{
    public class DTODødsfall
    {
        public long personnummer { get; set; }
        public string dødsårsak { get; set; }
        public DateTime dødsTid { get; set; }
    }
}
