// See https://aka.ms/new-console-template for more information
using Personregister.DTO;
using System.Net.Http.Json;
using System.Text.Json;

Console.WriteLine("Hello, World!");
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7213/");
await Task.Delay(20000);
//await createFødsel(client);

await createPersonerFraFil(client, ".\\Datafiler\\Personer.csv");
await createFødslerFraFil(client, ".\\Datafiler\\Fødsler.csv");
await createDødsfallFraFil(client, ".\\Datafiler\\Dødsfall.csv");
await getPersoner(client);
await getDødsfall(client);

async Task<Boolean> getPersoner(HttpClient client) 
{
    Console.WriteLine("\nPersoner:\n");
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

async Task<Boolean> getDødsfall(HttpClient client)
{
    Console.WriteLine("\nDØDSFALL:\n");
    try
    {
        List<DTOGetDødsfall> dødsfall = await client.GetFromJsonAsync<List<DTOGetDødsfall>>("Dødsfall");
        foreach (var d in dødsfall)
        {
            Console.WriteLine("Navn: "+d.fornavn +" " +"Dødsårsak: "+ d.dodsarsak);
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
            barn = new DTOBarn() { Fodselsdato = "667788", Fornavn = "fornavn", Etternavn = "etternavn" }
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
                barn = new DTOBarn() { Fodselsdato = data[2], Fornavn = data[3], Etternavn = data[4] }
            };
            var result = await client.PostAsJsonAsync<DTOFødsel>("Fødsel", fødselDTO);

            //Console.WriteLine(line);
        }

    }
    catch (Exception exception)
    {

        Console.WriteLine(exception.Message);
    }

    return true;
}

async Task<Boolean> createPersonerFraFil(HttpClient client, string filnavn)
{
    try
    {
        var lines = File.ReadAllLines(filnavn);
        foreach (var line in lines)
        {
            String[] data = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            DTOAddPerson personDTO = new DTOAddPerson()
            {
                fodselsnummer = Convert.ToInt64(data[0]),
                fornavn = data[1],
                etternavn = data[2]
            };
            var result = await client.PostAsJsonAsync<DTOAddPerson>("Person", personDTO);

            //Console.WriteLine(line);
        }

    }
    catch (Exception exception)
    {

        Console.WriteLine(exception.Message);
    }

    return true;
}

async Task<Boolean> createDødsfallFraFil(HttpClient client, string filnavn)
{
    try
    {
        var lines = File.ReadAllLines(filnavn);
        foreach (var line in lines)
        {
            String[] data = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            DTODødsfall dødsfallDTO = new DTODødsfall()
            {
                personnummer = Convert.ToInt64(data[0]),
                dodsarsak = data[1],
                dodsTid = DateTime.Parse(data[2])
            };
            var result = await client.PostAsJsonAsync<DTODødsfall>("Dødsfall", dødsfallDTO);

            //Console.WriteLine(line);
        }

    }
    catch (Exception exception)
    {

        Console.WriteLine(exception.Message);
    }

    return true;
}