using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace app4bybit
{
    public class BybitApi
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public BybitApi(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        private static string GenerateSignature(string data, string secretKey)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public async Task<string> GetWalletBalance()
        {
            string baseUrl = "https://api.bybit.com";
            string endpoint = "/v5/account/wallet-balance";
            string accountType = "UNIFIED";
            string coin = "BTC";
            string recvWindow = "5000";
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            
            var parameters = $"accountType={accountType}&coin={coin}&recvWindow={recvWindow}&timestamp={timestamp}";
            var signature = GenerateSignature(parameters, _apiSecret);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-BAPI-API-KEY", _apiKey);
                client.DefaultRequestHeaders.Add("X-BAPI-SIGN", signature);
                client.DefaultRequestHeaders.Add("X-BAPI-TIMESTAMP", timestamp);
                client.DefaultRequestHeaders.Add("X-BAPI-RECV-WINDOW", recvWindow);

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}{endpoint}?{parameters}");
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response:");
                    Console.WriteLine(responseBody);
                    return responseBody;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(errorResponse);
                    return errorResponse;
                }
            }
        }
    }
}
