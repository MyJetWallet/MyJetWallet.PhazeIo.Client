using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using MyJetWallet.PhazeIo.Client.Models;

namespace MyJetWallet.PhazeIo.Client;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class PhazeIoClient: IDisposable
{
    private readonly HttpClient _client;
    private readonly ILogger _logger;
    private readonly string _baseUrl;
    private readonly string _apiSecret;

    public PhazeIoClient(ILogger logger, string baseUrl, string apiKey, string apiSecret)
    {
        _logger = logger;
        _baseUrl = baseUrl;
        _apiSecret = apiSecret;

        if (_baseUrl.EndsWith('/'))
            _baseUrl += _baseUrl.Substring(0, _baseUrl.Length - 1);
        
        _client = new HttpClient
        {
            BaseAddress = new Uri(_baseUrl)
        };
        _client.DefaultRequestHeaders.Add("API-Key", $"{apiKey}");
    }

    public async Task<AccountStatusResponse> GetAccountStatus()
    {
        var resp = await GetRequest<AccountStatusResponse>("/accountstatus");
        return resp;
    }

    public async Task<WebhookItem> CreateWebhook(string backUrl, string backAuthHeaderName, string backAuthHeaderValue)
    {
        var request = new CreateWebhookRequest()
        {
            ApiKey = backAuthHeaderValue,
            AuthorizationHeaderName = backAuthHeaderName,
            Url = backUrl
        };

        var resp = await PostRequest<CreateWebhookRequest, WebhookItem>("/webhooks", request);
        return resp;
    }
    
    public async Task<List<WebhookItem>> GetWebhookList()
    {
        var resp = await GetRequest<List<WebhookItem>>("/webhooks");
        return resp;
    }
    
    public async Task DeleteWebhook(long webhookId)
    {
        await DeleteRequest($"/webhooks/{webhookId}");
    }

    public async Task<List<string>> GetBrandsCountries()
    {
        var resp = await GetRequest<List<string>>("/brands/countries");
        return resp;
    }
    
    public async Task<CardBrandListResponse> GetBrandsByCountry(string country, int page, string foreignCurrency = "")
    {
        var path = $"/brands/country/{country}?currentPage={page}";

        if (!string.IsNullOrEmpty(foreignCurrency))
        {
            path += $"&foreignCurrency={foreignCurrency}";
        }   
        
        var resp = await GetRequest<CardBrandListResponse>(path);
        return resp;
    }
    
    public async Task<CardBrand> GetBrandsByProductId(long productId, string currency = "")
    {
        var path = $"/brands/{productId}";

        if (!string.IsNullOrEmpty(currency))
        {
            path += $"?currency={currency}";
        }   
        
        var resp = await GetRequest<CardBrand>(path);
        return resp;
    }
    
    public async Task<PurchaseCardResponse> PurchaseCard(PurchaseCardRequest request)
    {
        if (request.Price == Math.Round(request.Price, 0))
            request.Price = Math.Round(request.Price, 0);
        
        var resp = await PostRequest<PurchaseCardRequest, PurchaseCardResponse>("/purchase", request);
        return resp;
    }
    
    public async Task<PurchaseCardRecord> GetPurchaseCardByOrderId(string orderId)
    {
        var resp = await GetRequest<PurchaseCardRecord>($"/transaction/{orderId}");
        return resp;
    }
    
    public async Task<GetPurchaseCardRecordListResponse> GetPurchaseCardList(int page, int perPage)
    {
        var resp = await GetRequest<GetPurchaseCardRecordListResponse>($"/transactions?currentPage={page}&perPage={perPage}");
        return resp;
    }

    private HttpClient GetClient()
    {
        return _client;
    }

    private async Task<T1> GetRequest<T1>(string path)
    {
        _logger.LogInformation("PhazeIo GET request to {path}", $"{path}");

        try
        {
            var client = GetClient();

            var content = $"GET{path}{_apiSecret}";
            var signature = HashWithSha256(content);
            
            var url = $"{_baseUrl}{path}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Signature", signature);
            
            var response = await client.SendAsync(request);
            var responseMessage = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError("Cannot call GET api. Url: {url} Status code: {code}. Response: {response}", url,
                    response.StatusCode, responseMessage);
                throw new PhazeIoException($"Cannot call GET '{url}'. Status code: {response.StatusCode}");
            }

            try
            {
                var data = JsonSerializer.Deserialize<T1>(responseMessage, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return data;
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    "Cannot deserialize response. Url: GET {url} Status code: {code}. Response: {response}",
                    url, response.StatusCode, responseMessage);
                throw new PhazeIoException($"Cannot call GET '{url}'. Can't deserialize response");
            }
        }
        catch (PhazeIoException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new PhazeIoException($"Cannot call GET '{path}'.", e);
        }
    }
    
    private async Task DeleteRequest(string path)
    {
        _logger.LogInformation("PhazeIo DELETE request to {path}", $"{path}");

        try
        {
            var client = GetClient();

            var content = $"DELETE{path}{_apiSecret}";
            var signature = HashWithSha256(content);
            
            var url = $"{_baseUrl}{path}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("Signature", signature);
            
            var response = await client.SendAsync(request);
            var responseMessage = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError("Cannot call DELETE api. Url: {url} Status code: {code}. Response: {response}", url,
                    response.StatusCode, responseMessage);
                throw new PhazeIoException($"Cannot call DELETE '{url}'. Status code: {response.StatusCode}");
            }
        }
        catch (PhazeIoException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new PhazeIoException($"Cannot call DELETE '{path}'.", e);
        }
    }

    private async Task<TResponse> PostRequest<TRequest, TResponse>(string path, TRequest requestBody)
    {
        _logger.LogInformation("PhazeIo POST request to {url}", $"{path}");

        try
        {
            var client = GetClient();
            
            var url = $"{_baseUrl}{path}";

            var json = JsonSerializer.Serialize(requestBody);
            
            var reqContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = reqContent;//new StringContent(json, Encoding.UTF8, "application/json");
            
            var content = $"POST{path}{_apiSecret}{reqContent.ReadAsStringAsync().Result}";
            var signature = HashWithSha256(content);
            
            request.Headers.Add("Signature", signature);
            
            var response = await client.SendAsync(request);
            var responseMessage = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = TryParseError(responseMessage);
                _logger.LogError("Cannot call api. Url: POST {url} Status code: {code}. Response: {response}", url,
                    response.StatusCode, responseMessage);
                throw new PhazeIoException($"Cannot call POST '{url}'. Status code: {response.StatusCode}: Error: {error?.Error}");
            }

            try
            {
                var data = JsonSerializer.Deserialize<TResponse>(responseMessage);
                return data;
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    "Cannot deserialize response. Url: POST {url} Status code: {code}. Response: {response}",
                    url, response.StatusCode, responseMessage);
                throw new PhazeIoException($"Cannot call POST '{url}'. Can't deserialize response");
            }
        }
        catch (PhazeIoException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new PhazeIoException($"Cannot call POST '{path}'.", e);
        }
    }

    private ErrorBody TryParseError(string content)
    {
        try
        {
            return JsonSerializer.Deserialize<ErrorBody>(content);
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    private static string HashWithSha256(string value)
    {
        using var hash = SHA256.Create();
        var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
        return Convert.ToHexString(byteArray).ToLower();
    }

    public void Dispose()
    {
        _client?.Dispose();
    }
}
