using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class PurchaseCardRequest
{
    [JsonPropertyName("orderId")] public string OrderId {get ; set;}
    [JsonPropertyName("price")] public decimal Price {get ; set;}
    [JsonPropertyName("productId")] public long ProductId {get ; set;}
    [JsonPropertyName("externalUserId")] public string ExternalUserId {get ; set;}
}

