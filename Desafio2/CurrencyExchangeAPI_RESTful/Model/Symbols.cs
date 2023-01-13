using System.Text.Json.Serialization;

public record class Symbol(
    [property: JsonPropertyName("code")] string Code);