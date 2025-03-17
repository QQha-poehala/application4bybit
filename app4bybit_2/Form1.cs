using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace app4bybit_2
{
    public partial class Form1 : Form
    {
        private readonly BybitApi _bybitApi;
        public Form1()
        {
            InitializeComponent();
            string API_KEY = "";
            string Secret_Key = "";
            _bybitApi = new BybitApi(API_KEY, Secret_Key); // First arg - API_KEY, second - Secret_Key
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем баланс в формате JSON
                var balanceJson = await _bybitApi.GetWalletBalance();
                var balanceData = JObject.Parse(balanceJson);

                if (balanceData["retCode"]?.ToString() == "0")
                {
                    var accounts = balanceData["result"]["list"] as JArray;
                    if (accounts != null && accounts.Count > 0)
                    {
                        var account = accounts[0];

                        var coins = account["coin"] as JArray;
                        if (coins != null)
                        {
                            terminal.Text += "-----------------------------------------------------------------------------------------------------\n ----------------------------------------МОИ МОНЕТЫ--------------------------------------------\n";
                            terminal.Text += $"Общий капитал счёта: {account["totalEquity"]?.ToString()}\n";
                            foreach (var coin in coins)
                            {
                                string coinName = coin["coin"]?.ToString();
                                string walletBalance = coin["walletBalance"]?.ToString();
                                string usdValue = coin["usdValue"]?.ToString();
                                terminal.Text += $"Монета: {coinName}; Количество: {walletBalance}; USDT coast: {usdValue}\n";
                            }
                        }
                        else
                            terminal.Text += "Список монет не найден в аккаунте.\n";
                    }
                    else
                        terminal.Text = "Список аккаунтов не найден в ответе.\n";
                }
                else
                    terminal.Text = $"Ошибка: {balanceData["retMsg"]?.ToString()}\n";
            }
            catch (Exception ex)
            {
                terminal.Text += $"Ошибка: {ex.Message}\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            terminal.Clear();
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            ThemeManager.ApplyTheme(form2);
            form2.ShowDialog();
        }
        // Загружаем сохранённую тему
        private void Form1_Load(object sender, EventArgs e)
        {
            string savedTheme = Properties.Settings.Default.Theme;
            if (savedTheme == "Dark")
                ThemeManager.ApplyTheme(this);
            else
                ThemeManager.ApplyTheme(this);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем баланс в формате JSON
                var historyJson = await _bybitApi.GetHistory();
                var historyData = JObject.Parse(historyJson);
                //terminal.Text += $"{historyJson}\n";
                if (historyData["retCode"]?.ToString() == "0")
                {
                    var transactions = historyData["result"]["list"] as JArray;
                    if (transactions != null && transactions.Count > 0)
                    {
                        terminal.Text += "-----------------------------------------------------------------------------------------------------\n -------------------------------------Журнал транзакций-----------------------------------------\n";
                        foreach (var transaction in transactions)
                        {
                            string symbol = transaction["symbol"]?.ToString();
                            string side = transaction["side"]?.ToString();
                            string type = transaction["type"]?.ToString();
                            string change = transaction["change"]?.ToString();
                            string currency = transaction["currency"]?.ToString();
                            string qty = transaction["qty"]?.ToString();
                            string transactionTime = transaction["transactionTime"]?.ToString();
                            string cashBalance = transaction["cashBalance"]?.ToString();
                            // Преобразуем время транзакции в читаемый формат
                            if (long.TryParse(transactionTime, out long timestamp))
                            {
                                DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
                                transactionTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            terminal.Text += $"Время: {transactionTime}\n";
                            terminal.Text += $"Тип: {type}; Направление: {side} ";
                            terminal.Text += $"Пара: {symbol}; Валюта: {currency} ";
                            terminal.Text += $"Изменение: {change}; Количество: {qty} ";
                            terminal.Text += $"Баланс после транзакции: {cashBalance}\n";
                            terminal.Text += "-----------------------------------------------------------------------------------------\n";
                        }
                    }
                    else
                        terminal.Text = "Список транзакций пуст.\n";
                }
                else
                    terminal.Text = $"Ошибка: {historyData["retMsg"]?.ToString()}\n";
            }
            catch (Exception ex)
            {
                terminal.Text += $"Ошибка: {ex.Message}\n";
            }
        }
    }
}
