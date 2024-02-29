using System.Globalization;

namespace MyJetWallet.PhazeIo.Client.Models;

public class AccountStatusResponse
{
    public AccountStatus Account { get; set; }

    public class AccountStatus
    {
        public string OrganizationName { get; set; }
        public string BaseCurrency { get; set; }
        public string Balance { get; set; }
        public decimal Last7DayTTV { get; set; }
        public decimal Last7DayCommission { get; set; }
        public string LastTopUpDate { get; set; }
        
        public decimal BalanceAsDecimal() => !string.IsNullOrEmpty(Balance) ? decimal.Parse(Balance, CultureInfo.InvariantCulture) : 0m;
    }
}