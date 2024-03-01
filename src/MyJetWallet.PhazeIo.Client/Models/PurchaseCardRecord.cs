using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class PurchaseCardRecord
{
    [DataMember(Order = 1), JsonPropertyName("id")] public long Id { get; set; }
    [DataMember(Order = 2), JsonPropertyName("accountId")] public long AccountId { get; set; }
    [DataMember(Order = 3), JsonPropertyName("orderId")] public string OrderId { get; set; }
    [DataMember(Order = 4), JsonPropertyName("productId")] public string ProductId { get; set; }
    [DataMember(Order = 5), JsonPropertyName("productName")] public string ProductName { get; set; }
    [DataMember(Order = 6), JsonPropertyName("externalUserId")] public string ExternalUserId { get; set; }

    [DataMember(Order = 7), JsonPropertyName("voucherDiscountPercent")] public decimal VoucherDiscountPercent { get; set; }

    [DataMember(Order = 8), JsonPropertyName("baseCurrency")] public string BaseCurrency { get; set; }
    [DataMember(Order = 9), JsonPropertyName("voucherCurrency")] public string VoucherCurrency { get; set; }
    [DataMember(Order = 10), JsonPropertyName("faceValue")] public decimal FaceValue { get; set; }
    [DataMember(Order = 11),JsonPropertyName("transactionFee")] public decimal TransactionFee { get; set; }

    [DataMember(Order = 12), JsonPropertyName("faceValueInBaseCurrency")] public decimal FaceValueInBaseCurrency { get; set; }

    [DataMember(Order = 13), JsonPropertyName("currencyConversions")] public Dictionary<string, decimal> CurrencyConversions { get; set; }

    [DataMember(Order = 14), JsonPropertyName("cost")] public decimal Cost { get; set; }
    [DataMember(Order = 15), JsonPropertyName("commission")] public decimal Commission { get; set; }
    [DataMember(Order = 16), JsonPropertyName("phazeCommission")] public decimal PhazeCommission { get; set; }
    [DataMember(Order = 17), JsonPropertyName("deliveryFee")] public decimal DeliveryFee { get; set; }
    [DataMember(Order = 18), JsonPropertyName("status")] public string Status { get; set; }
    
    [DataMember(Order = 19), JsonPropertyName("vouchers")] public List<Voucher> Vouchers { get; set; }

    [DataMember(Order = 20), JsonPropertyName("expiryAndValidity")]
    public string ExpiryAndValidity { get; set; }

    [DataMember(Order = 21), JsonPropertyName("transactionType")] public int TransactionType { get; set; }
    [DataMember(Order = 22), JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
    [DataMember(Order = 23), JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

    [JsonIgnore] public string ConversionPair => CurrencyConversions?.FirstOrDefault().Key;
    [JsonIgnore] public decimal ConversionRate => CurrencyConversions?.FirstOrDefault().Value ?? 0m;

    [JsonIgnore] public string VoucherUrl => Vouchers?.FirstOrDefault()?.Url;
    [JsonIgnore] public string VoucherCode => Vouchers?.FirstOrDefault()?.Code;
    [JsonIgnore] public string VoucherValidityDate => Vouchers?.FirstOrDefault()?.ValidityDate;
    [JsonIgnore] public string VoucherVoucherCurrency => Vouchers?.FirstOrDefault()?.VoucherCurrency;
    [JsonIgnore] public decimal VoucherFaceValue => Vouchers?.FirstOrDefault()?.FaceValue ?? 0m;
}