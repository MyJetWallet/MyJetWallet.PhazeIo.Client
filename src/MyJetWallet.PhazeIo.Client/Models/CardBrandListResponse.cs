using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class CardBrandListResponse
{
    [DataMember(Order = 1), JsonPropertyName("country")] public string Country { get; set; }
    [DataMember(Order = 2), JsonPropertyName("countryCode")] public string CountryCode { get; set; }
    [DataMember(Order = 3), JsonPropertyName("brands")] public List<CardBrand> Brands { get; set; }
    [DataMember(Order = 4), JsonPropertyName("currentPage")] public int CurrentPage { get; set; }
    [DataMember(Order = 5), JsonPropertyName("perPage")] public int PerPage { get; set; }
    [DataMember(Order = 6), JsonPropertyName("totalCount")] public int TotalCount { get; set; }
}