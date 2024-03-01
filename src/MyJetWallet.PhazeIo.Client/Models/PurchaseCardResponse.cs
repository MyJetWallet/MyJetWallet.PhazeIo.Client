using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class PurchaseCardResponse
{
    [DataMember(Order = 1), JsonPropertyName("id")] public long Id { get; set; }
    [DataMember(Order = 2), JsonPropertyName("accountId")] public long AccountId { get; set; }
    [DataMember(Order = 3), JsonPropertyName("partnerRevenueSharePercent")] public decimal PartnerRevenueSharePercent { get; set; }
    [DataMember(Order = 4), JsonPropertyName("orderId")] public string OrderId { get; set; }
    [DataMember(Order = 5), JsonPropertyName("productId")] public string ProductId { get; set; }
    [DataMember(Order = 6), JsonPropertyName("productName")] public string ProductName { get; set; }
    [DataMember(Order = 7), JsonPropertyName("externalUserId")] public string ExternalUserId { get; set; }
    [DataMember(Order = 8), JsonPropertyName("voucherDiscountPercent")] public decimal VoucherDiscountPercent { get; set; }
    [DataMember(Order = 9), JsonPropertyName("baseCurrency")] public string BaseCurrency { get; set; }
    [DataMember(Order = 10), JsonPropertyName("faceValue")] public decimal FaceValue { get; set; }
    [DataMember(Order = 11), JsonPropertyName("currencyConversions")] public Dictionary<string, decimal> CurrencyConversions { get; set; }
    [DataMember(Order = 12), JsonPropertyName("cost")] public decimal Cost { get; set; }
    [DataMember(Order = 13), JsonPropertyName("deliveryFee")] public decimal DeliveryFee { get; set; }
    [DataMember(Order = 14), JsonPropertyName("status")] public string Status { get; set; }
    [DataMember(Order = 15), JsonPropertyName("commission")] public decimal Commission { get; set; }
    [DataMember(Order = 16), JsonPropertyName("phazeCommission")] public decimal PhazeCommission { get; set; }
    [DataMember(Order = 17), JsonPropertyName("voucherCurrency")] public string VoucherCurrency { get; set; }
    [DataMember(Order = 18), JsonPropertyName("transactionFee")] public decimal TransactionFee { get; set; }
    [DataMember(Order = 19), JsonPropertyName("productDescription")] public string ProductDescription { get; set; }
    [DataMember(Order = 20), JsonPropertyName("termsAndConditions")] public string TermsAndConditions { get; set; }
    [DataMember(Order = 21), JsonPropertyName("howToUse")] public string HowToUse { get; set; }
    [DataMember(Order = 22), JsonPropertyName("expiryAndValidity")] public string ExpiryAndValidity { get; set; }
    [DataMember(Order = 23), JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
    [DataMember(Order = 24), JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }
}