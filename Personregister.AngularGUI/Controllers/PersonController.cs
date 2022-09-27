using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personregister.DTO;

namespace Personregister.AngularGUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        [HttpGet(Name = "GetPerson")]
        public async Task<IEnumerable<DTOPerson>> GetAsync()
        {
            //return _personService.getAll();
            //List<DTOPerson> persons = new List<DTOPerson>();
            //persons.Add(new DTOPerson() { navn = "person 1", kallenavn = "per1" });
            //persons.Add(new DTOPerson() { navn = "person2", kallenavn = "per2" });
            //return persons;

            Console.WriteLine("Hello, World!");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7213/");

            List<DTOPerson> personer = await client.GetFromJsonAsync<List<DTOPerson>>("Person");
            return personer;
        }

        [HttpPost]
        public async Task<Boolean> PostAsync(DTOAddPerson personDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7213/");
            var result = await client.PostAsJsonAsync<DTOAddPerson>("Person", personDTO);
            return true;
        }
    }
}
