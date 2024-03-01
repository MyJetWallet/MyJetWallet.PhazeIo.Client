using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class Voucher
{
    [DataMember(Order = 1), JsonPropertyName("url")] public string Url { get; set; }
    [DataMember(Order = 2), JsonPropertyName("code")] public string Code { get; set; }
    [DataMember(Order = 3), JsonPropertyName("validityDate")] public string ValidityDate { get; set; }
    [DataMember(Order = 4), JsonPropertyName("voucherCurrency")] public string VoucherCurrency { get; set; }
    [DataMember(Order = 5), JsonPropertyName("faceValue")] public decimal FaceValue { get; set; }
}