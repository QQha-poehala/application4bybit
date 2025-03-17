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
            string API_KEY = "gEFoibMvEjoxSTgTNj";
            string Secret_Key = "m4XiOtjgfKOwfG8hYs7JCjd3sMFYYhjchlbW";
            _bybitApi = new BybitApi(API_KEY, Secret_Key); // First arg - API_KEY, second - Secret_Key
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем баланс в формате JSON
                var balanceJson = await _bybitApi.GetWalletBalance();
                var balanceData = JObject.Parse(balanceJson);
                // Проверяем, успешен ли запрос

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
    }
}
