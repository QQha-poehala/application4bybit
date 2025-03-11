using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace app4bybit
{
    public partial class Form1 : Form
    {
        private readonly BybitApi _bybitApi;
        public Form1()
        {
            InitializeComponent();
            _bybitApi = new BybitApi("", ""); // First arg - API_KEY, second - Secret_Key
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var balanceJson = await _bybitApi.GetWalletBalance();
                var balanceData = JObject.Parse(balanceJson);
                // Пример вывода баланса BTC
                var btcBalance = balanceData["result"]["BTC"]["available_balance"];
                terminal.Text += $"BTC Balance: {balanceData}\\";
            }
            catch (Exception ex)
            {
                terminal.Text += $"Ошибка: {ex.Message}\n";
            }

        }
    }
}
