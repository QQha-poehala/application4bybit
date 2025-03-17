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
            _accountService = new BybitAccountService(apiKey, apiSecret, "https://api.bybit.com");
        }
        public async Task<string> GetWalletBalance()
        {
            // Получение баланса кошелька
            string? result = await _accountService.GetAccountBalance(AccountType.Unified);
            return result;
        }
        public async Task<string> GetHistory()
        {
            // Получение баланса кошелька
            string? result = await _accountService.GetAccountTransaction();
            return result;

        }
    }
}
