using PetStore.Enums;
using System.Text.Json;

namespace PetStore.Utilities
{
    public static class Extensions
    {
        public static bool IsEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }
        public static bool IsAny<T>(this List<T> list)
        {
            return list != null && list.Count > 0;
        }

        public static T? ParseJsonStringTo<T>(this string response)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new CaseInsensitiveEnumConverter<PetAvailabilityEnum>() }
                };

                return JsonSerializer.Deserialize<T>(response, options);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON string: {ex.Message}");
                return default;
            }
        }
    }
}
