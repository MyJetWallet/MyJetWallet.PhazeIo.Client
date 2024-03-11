using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class CardBrand
{
    [DataMember(Order = 1), JsonPropertyName("brandName")] public string BrandName { get; set; }
    [DataMember(Order = 2), JsonPropertyName("countryName")] public string CountryName { get; set; }
    [DataMember(Order = 3), JsonPropertyName("currency")] public string Currency { get; set; }
    [DataMember(Order = 4), JsonPropertyName("denominations")] public List<decimal> Denominations { get; set; }
    [DataMember(Order = 5), JsonPropertyName("valueRestrictions")] public ValueRestrictionsModel ValueRestrictions { get; set; }
    [DataMember(Order = 6), JsonPropertyName("foreignValueRestrictions")] public ValueRestrictionsModel ForeignValueRestrictions { get; set; }
    
    [DataMember(Order = 7), JsonPropertyName("productId")] public long ProductId { get; set; }
    [DataMember(Order = 8), JsonPropertyName("productImage")] public string ProductImage { get; set; }
    [DataMember(Order = 9), JsonPropertyName("productDescription")] public string ProductDescription { get; set; }
    [DataMember(Order = 10), JsonPropertyName("termsAndConditions")] public string TermsAndConditions { get; set; }
    [DataMember(Order = 11), JsonPropertyName("howToUse")] public string HowToUse { get; set; }
    [DataMember(Order = 12), JsonPropertyName("expiryAndValidity")] public string ExpiryAndValidity { get; set; }
    [DataMember(Order = 13), JsonPropertyName("discount")] public decimal Discount { get; set; }
    
    
}

[DataContract]
public class ValueRestrictionsModel
{
    [DataMember(Order = 1), JsonPropertyName("maxVal")] public decimal MaxVal { get; set; }
    [DataMember(Order = 2), JsonPropertyName("minVal")] public decimal MinVal { get; set; }
}