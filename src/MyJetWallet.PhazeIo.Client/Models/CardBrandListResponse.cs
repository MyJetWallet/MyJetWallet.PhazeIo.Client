using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class CardBrandListResponse
{
    [JsonPropertyName("country")] public string Country { get; set; }
    [JsonPropertyName("countryCode")] public string CountryCode { get; set; }
    [JsonPropertyName("brands")] public List<CardBrand> Brands { get; set; }
    [JsonPropertyName("currentPage")] public int CurrentPage { get; set; }
    [JsonPropertyName("perPage")] public int PerPage { get; set; }
    [JsonPropertyName("totalCount")] public int TotalCount { get; set; }
}