using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class WebhookItem
{
    [JsonPropertyName("id")] public long Id {get ; set;}
    [JsonPropertyName("accountId")] public long AccountId { get; set; }
    [JsonPropertyName("apiKey")] public string ApiKey { get; set; }
    [JsonPropertyName("authorizationHeaderName")] public string AuthorizationHeaderName { get; set; }
    [JsonPropertyName("url")] public string Url { get; set; }
    [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
}