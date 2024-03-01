using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class PurchaseCardResponse
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("accountId")] public long AccountId { get; set; }
    [JsonPropertyName("partnerRevenueSharePercent")] public decimal PartnerRevenueSharePercent { get; set; }
    [JsonPropertyName("orderId")] public string OrderId { get; set; }
    [JsonPropertyName("productId")] public string ProductId { get; set; }
    [JsonPropertyName("productName")] public string ProductName { get; set; }
    [JsonPropertyName("externalUserId")] public string ExternalUserId { get; set; }
    [JsonPropertyName("voucherDiscountPercent")] public decimal VoucherDiscountPercent { get; set; }
    [JsonPropertyName("baseCurrency")] public string BaseCurrency { get; set; }
    [JsonPropertyName("faceValue")] public decimal FaceValue { get; set; }
    [JsonPropertyName("currencyConversions")] public Dictionary<string, decimal> CurrencyConversions { get; set; }
    [JsonPropertyName("cost")] public decimal Cost { get; set; }
    [JsonPropertyName("deliveryFee")] public decimal DeliveryFee { get; set; }
    [JsonPropertyName("status")] public string Status { get; set; }
    [JsonPropertyName("commission")] public decimal Commission { get; set; }
    [JsonPropertyName("phazeCommission")] public decimal PhazeCommission { get; set; }
    [JsonPropertyName("voucherCurrency")] public string VoucherCurrency { get; set; }
    [JsonPropertyName("transactionFee")] public decimal TransactionFee { get; set; }
    [JsonPropertyName("productDescription")] public string ProductDescription { get; set; }
    [JsonPropertyName("termsAndConditions")] public string TermsAndConditions { get; set; }
    [JsonPropertyName("howToUse")] public string HowToUse { get; set; }
    [JsonPropertyName("expiryAndValidity")] public string ExpiryAndValidity { get; set; }
    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }
}