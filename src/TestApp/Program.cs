// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using MyJetWallet.PhazeIo.Client;
using MyJetWallet.PhazeIo.Client.Models;

Console.WriteLine("Hello, World!");

var client = new PhazeIoClient(NullLogger<PhazeIoClient>.Instance, "https://api.sandbox.phaze.io", 
    Environment.GetEnvironmentVariable("API_KEY"), 
    Environment.GetEnvironmentVariable("API_SECRET"));

var accountStatus = await client.GetAccountStatus();

Console.WriteLine("Account status: \n" + JsonSerializer.Serialize(accountStatus, new JsonSerializerOptions() { WriteIndented = true }));
Console.WriteLine(accountStatus.Account.BalanceAsDecimal().ToString(CultureInfo.InvariantCulture));

//var addWebhookResp = await client.CreateWebhook("https://webhook-uat.simple-spot.biz/phaze/webhook/444/", "auth", "test"); 
//Console.WriteLine($"Add Webhook: \n {JsonSerializer.Serialize(addWebhookResp, new JsonSerializerOptions() { WriteIndented = true })}");
//await client.DeleteWebhook(addWebhookResp.Id);

// var webhookList = await client.GetWebhookList();
// Console.WriteLine($"Webhook list: \n {JsonSerializer.Serialize(webhookList, new JsonSerializerOptions() { WriteIndented = true })}");

// var counries = await client.GetBrandsCountries();
// Console.WriteLine($"Brands countries: \n {JsonSerializer.Serialize(counries, new JsonSerializerOptions() { WriteIndented = true })}");
//
// var page = 1;
// var index = 0;
// CardBrandListResponse? brands;
// do
// {
//     brands = await client.GetBrandsByCountry("Poland", page);
//     //Console.WriteLine($"Brands countries: \n {JsonSerializer.Serialize(brands, new JsonSerializerOptions() { WriteIndented = true })}");
//     foreach (var brand in brands.Brands)
//     {
//         index++;
//         Console.WriteLine($"{index}\t{brand.ProductId}\t{brand.BrandName}\t| {brand.Currency} ; {brand.Discount}");
//     }
//
//     page++;
// }while (brands?.Brands?.Any() == true);
//
// Console.WriteLine();
// Console.WriteLine();
//
var singleBrand = await client.GetBrandsByProductId(103102207337);
Console.WriteLine($"Brand: \n {JsonSerializer.Serialize(singleBrand, new JsonSerializerOptions() { WriteIndented = true })}");

Console.WriteLine();
Console.WriteLine();
Console.ReadLine();

// var orderId = Guid.NewGuid().ToString();
// Console.WriteLine(orderId);
//
// var orderPurchase = await client.PurchaseCard(new PurchaseCardRequest()
// {
//     ProductId = 103162207337,
//     ExternalUserId = "test_001",
//     Price = 5,
//     OrderId = orderId
// });
//
// Console.WriteLine("Purchase: \n" + JsonSerializer.Serialize(orderPurchase, new JsonSerializerOptions() { WriteIndented = true }));
//
// Console.WriteLine();
// var purchaseRecord = await client.GetPurchaseCardByOrderId(orderId);
// Console.WriteLine("Purchase record: \n" + JsonSerializer.Serialize(purchaseRecord, new JsonSerializerOptions() { WriteIndented = true }));
//
// Console.ReadLine();
// Console.WriteLine();
// purchaseRecord = await client.GetPurchaseCardByOrderId(orderId);
// Console.WriteLine("Purchase record: \n" + JsonSerializer.Serialize(purchaseRecord, new JsonSerializerOptions() { WriteIndented = true }));
// Console.WriteLine(purchaseRecord.VoucherUrl);

//var purchaseList = await client.GetPurchaseCardList(1, 10);
//Console.WriteLine("Purchase list: \n" + JsonSerializer.Serialize(purchaseList, new JsonSerializerOptions() { WriteIndented = true }));

var countries = await client.GetBrandsCountries();
Dictionary<string, List<String>> brandNames = new Dictionary<string, List<string>>();
foreach (var country in countries)
{
    var names = new List<string>();
    CardBrandListResponse data;
    var page = 1;
    do
    {
        data = await client.GetBrandsByCountry(country, page);
        var res = data.Brands ?? new List<CardBrand>();
        var resSelector = res.AsEnumerable();
        resSelector = resSelector.Where(e => e.BrandName.Contains("USD Mobile Wallet (Virtual only)"));
        //resSelector = resSelector.Where(e => e.BrandName.ToUpper().Contains("VISA") || e.BrandName.ToUpper().Contains("MASTERCARD"));
        resSelector = resSelector.Where(e => e.BrandName.ToUpper().Contains("MOBILE WALLET"));
        names.AddRange(resSelector.Select(e => $"{e.BrandName}  ({e.ProductId})"));
        page++;
    } while( data.Brands?.Any() == true);

    if (names.Any())
        brandNames[country] = names;
    Console.WriteLine($"{country}\t{names.Count}");
}

foreach (var pair in brandNames)
{
    foreach (var brand in pair.Value)
    {
        Console.WriteLine($"{pair.Key}\t{brand}");
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Press enter to exit");
Console.ReadLine();

