using MyNoSqlServer.Abstractions;

namespace MyJetWallet.PhazeIo.Client.Models
{
    public class CardBrandNoSql: MyNoSqlDbEntity
    {
        public const string TableName = "jetwallet-phazeio-cardbrand";
        
        public static string GeneratePartitionKey(string countryName) => countryName;
        public static string GenerateRowKey(string brandName) => brandName;
        
        public CardBrand CardBrand { get; set; }

        public static CardBrandNoSql Create(CardBrand cardBrand)
        {
            return new CardBrandNoSql()
            {
                PartitionKey = GeneratePartitionKey(cardBrand.CountryName),
                RowKey = GenerateRowKey(cardBrand.BrandName),
                CardBrand = cardBrand
            };
        }
    }
}