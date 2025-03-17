using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using bybit.net.api;
using bybit.net.api.Models;
using bybit.net.api.Services;
using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models.Account;
using System.Collections.Generic;


namespace app4bybit_2
{
    public class BybitApi
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly BybitAccountService _accountService;

        public BybitApi(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _accountService = new BybitAccountService(apiKey, apiSecret, "https://api.bybit.com", "10000");
        }
        // TODO: change timestamp. GetAccountBalance и GetAccountTransaction не предоставляют такую возможность,BybitAccountService тоже. Не понимаю как исправить
        //private string CreateSignature(string secret, string queryString)
        //{
        //    using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
        //    {
        //        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(queryString));
        //        return BitConverter.ToString(hash).Replace("-", "").ToLower();
        //    }
        //}   
        //private long GetCurrentTimestamp()
        //{
        //    return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        //}
        public async Task<string> GetWalletBalance()
        {
            return await _accountService.GetAccountBalance(AccountType.Unified);
        }
        public async Task<string> GetHistory()
        {
            return  await _accountService.GetAccountTransaction(limit: 100);
        }
    }
}
