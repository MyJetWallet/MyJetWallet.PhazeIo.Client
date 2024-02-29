using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class CreateWebhookRequest
{
    [JsonPropertyName("apiKey")] public string ApiKey {get ; set;}
    [JsonPropertyName("authorizationHeaderName")] public string AuthorizationHeaderName { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; }
}