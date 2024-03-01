using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class ErrorBody
{
    [DataMember(Order = 1), JsonPropertyName("error")] public string Error { get; set; }
    [DataMember(Order = 2), JsonPropertyName("httpStatusCode")] public int HttpStatusCode { get; set; }
}