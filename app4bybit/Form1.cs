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

namespace app4bybit
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
                var balanceJson = await _bybitApi.GetWalletBalance();
                terminal.Text = balanceJson.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("warning");
                terminal.Text += $"Ошибка: {ex.Message}\n";
            }

        }
    }
}
