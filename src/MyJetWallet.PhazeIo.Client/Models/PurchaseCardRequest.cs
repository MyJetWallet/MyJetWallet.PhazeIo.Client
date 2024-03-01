using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class PurchaseCardRequest
{
    [DataMember(Order = 1), JsonPropertyName("orderId")] public string OrderId {get ; set;}
    [DataMember(Order = 2), JsonPropertyName("price")] public decimal Price {get ; set;}
    [DataMember(Order = 3), JsonPropertyName("productId")] public long ProductId {get ; set;}
    [DataMember(Order = 4), JsonPropertyName("externalUserId")] public string ExternalUserId {get ; set;}
}

