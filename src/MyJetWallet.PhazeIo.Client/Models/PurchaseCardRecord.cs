using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class PurchaseCardRecord
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("accountId")] public long AccountId { get; set; }
    [JsonPropertyName("orderId")] public string OrderId { get; set; }
    [JsonPropertyName("productId")] public string ProductId { get; set; }
    [JsonPropertyName("productName")] public string ProductName { get; set; }
    [JsonPropertyName("externalUserId")] public string ExternalUserId { get; set; }

    [JsonPropertyName("voucherDiscountPercent")]
    public decimal VoucherDiscountPercent { get; set; }

    [JsonPropertyName("baseCurrency")] public string BaseCurrency { get; set; }
    [JsonPropertyName("voucherCurrency")] public string VoucherCurrency { get; set; }
    [JsonPropertyName("faceValue")] public decimal FaceValue { get; set; }
    [JsonPropertyName("transactionFee")] public decimal TransactionFee { get; set; }

    [JsonPropertyName("faceValueInBaseCurrency")]
    public decimal FaceValueInBaseCurrency { get; set; }

    [JsonPropertyName("currencyConversions")]
    public Dictionary<string, decimal> CurrencyConversions { get; set; }

    [JsonPropertyName("cost")] public decimal Cost { get; set; }
    [JsonPropertyName("commission")] public decimal Commission { get; set; }
    [JsonPropertyName("phazeCommission")] public decimal PhazeCommission { get; set; }
    [JsonPropertyName("deliveryFee")] public decimal DeliveryFee { get; set; }
    [JsonPropertyName("status")] public string Status { get; set; }
    
    [JsonPropertyName("vouchers")] public List<Voucher> Vouchers { get; set; }

    [JsonPropertyName("expiryAndValidity")]
    public string ExpiryAndValidity { get; set; }

    [JsonPropertyName("transactionType")] public int TransactionType { get; set; }
    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

    [JsonIgnore] public string ConversionPair => CurrencyConversions?.FirstOrDefault().Key;
    [JsonIgnore] public decimal ConversionRate => CurrencyConversions?.FirstOrDefault().Value ?? 0m;

    [JsonIgnore] public string VoucherUrl => Vouchers?.FirstOrDefault()?.Url;
    [JsonIgnore] public string VoucherCode => Vouchers?.FirstOrDefault()?.Code;
    [JsonIgnore] public string VoucherValidityDate => Vouchers?.FirstOrDefault()?.ValidityDate;
    [JsonIgnore] public string VoucherVoucherCurrency => Vouchers?.FirstOrDefault()?.VoucherCurrency;
    [JsonIgnore] public decimal VoucherFaceValue => Vouchers?.FirstOrDefault()?.FaceValue ?? 0m;
}