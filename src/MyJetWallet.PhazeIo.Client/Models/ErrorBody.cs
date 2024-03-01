using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class ErrorBody
{
    [JsonPropertyName("error")] public string Error { get; set; }
    [JsonPropertyName("httpStatusCode")] public int HttpStatusCode { get; set; }
}