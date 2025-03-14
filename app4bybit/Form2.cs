using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app4bybit
{
    public partial class Form2 : Form
    {
        Form1 _form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void Light_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme == "Dark")
            {
                ThemeManager.ApplyLightTheme(this);
                ThemeManager.ApplyLightTheme(_form1); 
                Properties.Settings.Default.Theme = "Light";
            }
            else
                MessageBox.Show("Тема уже светлая", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Properties.Settings.Default.Save(); // Сохраняем настройки
        }

        private void Dark_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Theme == "Light")
            {
                ThemeManager.ApplyDarkTheme(this);
                ThemeManager.ApplyDarkTheme(_form1);
                Properties.Settings.Default.Theme = "Dark";
            }
            else
                MessageBox.Show("Тема уже тёмная", "Уведомление", MessageBoxButtons.OK,MessageBoxIcon.Warning);

            Properties.Settings.Default.Save(); // Сохраняем настройки
        }
    }
}
