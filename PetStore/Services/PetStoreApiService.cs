using PetStore.Models;
using PetStore.Utilities;

namespace PetStore.SErvices
{
    public class PetStoreApiService
    {
        private string _apiUrl;
        private readonly HttpClient _httpClient;

        public PetStoreApiService(string apiUrl, HttpClient httpClient)
        {
            _apiUrl = apiUrl;
            _httpClient = httpClient;
        }

        public async Task PrintSortedAvailablePets()
        {
            var operationName = "findByStatus";
            var status = "available";

            try
            {
                var stringResponse = await GetApiResponse($"{_apiUrl}/{operationName}?status={status}");
                var availablePets = stringResponse.ParseJsonStringTo<List<Pet>>();

                if (availablePets.IsAny())
                {
                    var sortedAvailablePets = availablePets.OrderBy(p => p.Category?.Name)
                                 .ThenByDescending(p => p.Name)
                                 .ToList();

                    PrintAvailablePets(sortedAvailablePets);
                }
                else
                {
                    Console.WriteLine("No pets available.");
                    return;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task<string> GetApiResponse(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private void PrintAvailablePets(List<Pet> pets)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine($"Category: {pet.Category?.Name}, Pet Name: {pet.Name}");
            }
        }
    }
}
