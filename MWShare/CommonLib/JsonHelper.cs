using System.Text.Json;

namespace CommonLib
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerOptions defaultJsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //PropertyNamingPolicy = null,
            WriteIndented = false,
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip
        };

        public static string Serialize<T>(T value, JsonSerializerOptions serializerOptions = null)
        {
            return JsonSerializer.Serialize(value, serializerOptions ?? defaultJsonSerializerOptions);
        }
        public static T Deserialize<T>(string value, JsonSerializerOptions serializerOptions = null)
        {
            return JsonSerializer.Deserialize<T>(value, serializerOptions ?? defaultJsonSerializerOptions);
        }
    }
}
