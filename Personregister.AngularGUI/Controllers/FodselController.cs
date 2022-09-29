using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personregister.DTO;

namespace Personregister.AngularGUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FodselController : ControllerBase
    {
        [HttpGet(Name = "GetFødsel")]
        public async Task<IEnumerable<DTOGetFødsel>> GetAsync()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7213/");

            List<DTOGetFødsel> fødsler = await client.GetFromJsonAsync<List<DTOGetFødsel>>("Fødsel");
            return fødsler;
        }

        [HttpPost]
        public async Task<Boolean> PostAsync(DTOFødsel addFodselDTO)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7213/");
            var result = await client.PostAsJsonAsync<DTOFødsel>("Fødsel", addFodselDTO);
            return true;
        }
    }
}
