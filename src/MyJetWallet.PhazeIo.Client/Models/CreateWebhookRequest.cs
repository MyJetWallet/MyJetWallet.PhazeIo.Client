using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class CreateWebhookRequest
{
    [DataMember(Order = 1), JsonPropertyName("apiKey")] public string ApiKey {get ; set;}
    [DataMember(Order = 2), JsonPropertyName("authorizationHeaderName")] public string AuthorizationHeaderName { get; set; }
    [DataMember(Order = 3), JsonPropertyName("url")] public string Url { get; set; }
}