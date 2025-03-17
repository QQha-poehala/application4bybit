using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using bybit.net.api;


namespace app4bybit_2
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
        public async Task<string> GetWalletBalance()
        {
            string baseUrl = "https://api.bybit.com";
            string endpoint = "/v5/account/wallet-balance";
            string accountType = "UNIFIED";
            //string coin = "USDT";
            string recvWindow = "10000";
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            
            var parameters = $"accountType={accountType}";
            var signature = GenerateSignature(timestamp, parameters, recvWindow);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-BAPI-API-KEY", _apiKey);
                client.DefaultRequestHeaders.Add("X-BAPI-SIGN", signature);
                client.DefaultRequestHeaders.Add("X-BAPI-TIMESTAMP", timestamp.ToString());
                client.DefaultRequestHeaders.Add("X-BAPI-RECV-WINDOW", recvWindow);

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}{endpoint}?{parameters}");
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Ответ сервака:");
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
        // Метод для генерации подписи
        private string GenerateSignature(long timestamp, string queryParams, string recvWindow)
        {
            string dataToSign = $"{timestamp}{_apiKey}{recvWindow}{queryParams}";
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(_apiSecret);
            byte[] dataBytes = Encoding.UTF8.GetBytes(dataToSign);

            using (var hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(dataBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
