using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personregister.DTO;

namespace Personregister.AngularGUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DodsfallController : ControllerBase
    {
        [HttpGet(Name = "GetDødsfall")]
        public async Task<IEnumerable<DTOGetDødsfall>> GetAsync()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7213/");

            List<DTOGetDødsfall> dødsfall = await client.GetFromJsonAsync<List<DTOGetDødsfall>>("Dødsfall");
            return dødsfall;
        }

        [HttpPost]
        public async Task<Boolean> PostAsync(DTODødsfall dødsfallDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7213/");
            var result = await client.PostAsJsonAsync<DTODødsfall>("Dødsfall", dødsfallDTO);
            return true;
        }
    }
}
