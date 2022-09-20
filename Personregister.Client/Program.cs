// See https://aka.ms/new-console-template for more information
using Personregister.DTO;
using System.Net.Http.Json;
using System.Text.Json;

Console.WriteLine("Hello, World!");
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7213/");
await Task.Delay(2000);
await createFødsel(client);
await createFødslerFraFil(client, ".\\Datafiler\\Fødsler.csv");
await getPersoner(client);

async Task<Boolean> getPersoner(HttpClient client) 
{
    try
    {

        List<DTOPerson> personer = await client.GetFromJsonAsync<List<DTOPerson>>("Person");
        foreach (var person in personer)
        {
            Console.WriteLine(person.navn);
        }
    }
    catch (Exception exception)
    {

        Console.WriteLine(exception.Message);
    }
    return true;    
}

async Task<Boolean> createFødsel(HttpClient client)
{
    try
    {
        DTOFødsel fødselDTO = new DTOFødsel()
        {
            personnummerMor = 11223344556,
            personnummerFar = 22334455676,
            barn = new DTOBarn() { Personnummer = 66778899009, Fornavn = "fornavn", Etternavn = "etternavn" }
        };

        var result = await client.PostAsJsonAsync<DTOFødsel>("Fødsel", fødselDTO);

    }
    catch (Exception exception)
    {

        Console.WriteLine(exception.Message);
    }

    return true;
}

async Task<Boolean> createFødslerFraFil(HttpClient client, string filnavn)
{
    try
    {
        var lines = File.ReadAllLines(filnavn);
        foreach (var line in lines)
        {
            String[] data = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            DTOFødsel fødselDTO = new DTOFødsel()
            {
                personnummerMor = Convert.ToInt64(data[0]),
                personnummerFar = Convert.ToInt64(data[1]),
                barn = new DTOBarn() { Personnummer = Convert.ToInt64(data[2]), Fornavn = data[3], Etternavn = data[4] }
            };
            var result = await client.PostAsJsonAsync<DTOFødsel>("Fødsel", fødselDTO);

            Console.WriteLine(line);
        }

    }
    catch (Exception exception)
    {

        Console.WriteLine(exception.Message);
    }

    return true;
}
