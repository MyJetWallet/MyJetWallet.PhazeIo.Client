using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class WebhookItem
{
    [DataMember(Order = 1), JsonPropertyName("id")] public long Id {get ; set;}
    [DataMember(Order = 2), JsonPropertyName("accountId")] public long AccountId { get; set; }
    [DataMember(Order = 3), JsonPropertyName("apiKey")] public string ApiKey { get; set; }
    [DataMember(Order = 4), JsonPropertyName("authorizationHeaderName")] public string AuthorizationHeaderName { get; set; }
    [DataMember(Order = 5), JsonPropertyName("url")] public string Url { get; set; }
    [DataMember(Order = 6), JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }
    [DataMember(Order = 7), JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
}