

using System.Text.Json;
using System.Text.Json.Serialization;

using OneOf;

namespace ECAIService.Serializers;

public class OneOfJsonConverter : JsonConverter<IOneOf>
{
    public override IOneOf? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, IOneOf value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
    }

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.GetInterfaces().Contains(typeof(IOneOf));
    }
}
