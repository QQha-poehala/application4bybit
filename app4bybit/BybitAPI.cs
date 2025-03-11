using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

        private string GenerateSignature(string parameters)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_apiSecret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(parameters));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public async Task<string> GetWalletBalance()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            var parameters = $"api_key={_apiKey}&timestamp={timestamp}";
            var signature = GenerateSignature(parameters);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-BAPI-API-KEY", _apiKey);
                client.DefaultRequestHeaders.Add("X-BAPI-SIGN", signature);
                client.DefaultRequestHeaders.Add("X-BAPI-TIMESTAMP", timestamp);

                var response = await client.GetAsync($"https://api.bybit.com/v2/private/wallet/balance?{parameters}&sign={signature}");
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
