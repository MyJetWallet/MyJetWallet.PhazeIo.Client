using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class CardBrand
{
    [JsonPropertyName("brandName")] public string BrandName { get; set; }
    [JsonPropertyName("countryName")] public string CountryName { get; set; }
    [JsonPropertyName("currency")] public string Currency { get; set; }
    [JsonPropertyName("denominations")] public List<decimal> Denominations { get; set; }
    [JsonPropertyName("valueRestrictions")] public ValueRestrictionsModel ValueRestrictions { get; set; }
    [JsonPropertyName("productId")] public long ProductId { get; set; }
    [JsonPropertyName("productImage")] public string ProductImage { get; set; }
    [JsonPropertyName("productDescription")] public string ProductDescription { get; set; }
    [JsonPropertyName("termsAndConditions")] public string TermsAndConditions { get; set; }
    [JsonPropertyName("howToUse")] public string HowToUse { get; set; }
    [JsonPropertyName("expiryAndValidity")] public string ExpiryAndValidity { get; set; }
    [JsonPropertyName("discount")] public decimal Discount { get; set; }
    
    public class ValueRestrictionsModel
    {
        [JsonPropertyName("MaxVal")] public decimal? MaxVal { get; set; }
        [JsonPropertyName("MinVal")] public decimal? MinVal { get; set; }
    }
}