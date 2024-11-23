﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace MWAuth.CustomConverters
{
    public class CustomInt32Converter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                int.TryParse(reader.GetString(), out int valueInt);
                return valueInt;
            }

            return reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
