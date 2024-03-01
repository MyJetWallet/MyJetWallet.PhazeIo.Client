using System.Globalization;
using System.Runtime.Serialization;

namespace MyJetWallet.PhazeIo.Client.Models;

[DataContract]
public class AccountStatusResponse
{
    [DataMember(Order = 1)] public AccountStatus Account { get; set; }

    [DataContract]
    public class AccountStatus
    {
        [DataMember(Order = 1)] public string OrganizationName { get; set; }
        [DataMember(Order = 2)] public string BaseCurrency { get; set; }
        [DataMember(Order = 3)] public string Balance { get; set; }
        [DataMember(Order = 4)] public decimal Last7DayTTV { get; set; }
        [DataMember(Order = 5)] public decimal Last7DayCommission { get; set; }
        [DataMember(Order = 6)] public string LastTopUpDate { get; set; }
        
        public decimal BalanceAsDecimal() => !string.IsNullOrEmpty(Balance) ? decimal.Parse(Balance, CultureInfo.InvariantCulture) : 0m;
    }
}