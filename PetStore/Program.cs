// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using PetStore.SErvices;

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

if (configuration != null)
{
    string? baseUrl = configuration["PetStoreApi:BaseUrl"];

    if (!string.IsNullOrEmpty(baseUrl))
    {
        using (HttpClient httpClient = new HttpClient())
        {
            var petStoreApiService = new PetStoreApiService(baseUrl, httpClient);
            await petStoreApiService.PrintSortedAvailablePets();
        }
    }
    else
    {
        Console.WriteLine($"Error: Missing configuration entry.");
    }
}
else
{
    Console.WriteLine($"Error: Error loading configuration file.");
}