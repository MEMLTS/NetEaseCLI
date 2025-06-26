using System.Text.Json.Serialization;

namespace NetEaseCLI.Model;

public class SignModel
{
    [JsonPropertyName("params")]
    public required string Param { get; set; }
    
    [JsonPropertyName("encSecKey")]
    public required string EncSecKey { get; set; }
}