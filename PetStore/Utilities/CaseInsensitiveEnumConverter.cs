using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetStore.Utilities
{
    internal class CaseInsensitiveEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct
    {
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string enumString = reader.GetString();
                if (Enum.TryParse<TEnum>(enumString, true, out TEnum result))
                {
                    return result;
                }
            }

            // Fallback to default value on failure
            return default;
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            // Serialize the enum as a string
            writer.WriteStringValue(value.ToString());
        }
    }
}
