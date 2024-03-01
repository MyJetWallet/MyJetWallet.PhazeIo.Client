using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class GetPurchaseCardRecordListResponse
{
    [JsonPropertyName("result")] public List<PurchaseCardRecord> Result { get; set; }
    [JsonPropertyName("currentPage")] public int CurrentPage { get; set; }
    [JsonPropertyName("perPage")] public int PerPage { get; set; }
    [JsonPropertyName("totalCount")] public int TotalCount { get; set; }
}