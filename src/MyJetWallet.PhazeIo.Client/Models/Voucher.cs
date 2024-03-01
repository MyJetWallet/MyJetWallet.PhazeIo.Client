using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class Voucher
{
    [JsonPropertyName("url")] public string Url { get; set; }
    [JsonPropertyName("code")] public string Code { get; set; }
    [JsonPropertyName("validityDate")] public string ValidityDate { get; set; }
    [JsonPropertyName("voucherCurrency")] public string VoucherCurrency { get; set; }
    [JsonPropertyName("faceValue")] public decimal FaceValue { get; set; }
}