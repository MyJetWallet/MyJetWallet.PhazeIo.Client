using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class GetPurchaseCardRecordListResponse
{
    [DataMember(Order = 1), JsonPropertyName("result")] public List<PurchaseCardRecord> Result { get; set; }
    [DataMember(Order = 2), JsonPropertyName("currentPage")] public int CurrentPage { get; set; }
    [DataMember(Order = 3), JsonPropertyName("perPage")] public int PerPage { get; set; }
    [DataMember(Order = 4), JsonPropertyName("totalCount")] public int TotalCount { get; set; }
}