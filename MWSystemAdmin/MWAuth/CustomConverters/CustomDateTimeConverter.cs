using System.Text.Json;
using System.Text.Json.Serialization;

namespace MWAuth.CustomConverters
{
    public sealed class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && string.IsNullOrEmpty(reader.GetString()))
                return DateTime.MinValue;

            return reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }

    public sealed class CustomNullableDateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if ((reader.TokenType == JsonTokenType.String && string.IsNullOrEmpty(reader.GetString()))
                || reader.TokenType == JsonTokenType.Null)
                return null;

            return reader.GetDateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value != null)
                writer.WriteStringValue(value.GetValueOrDefault());
        }
    }
}
