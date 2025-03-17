using System;
using System.Drawing;
using System.Windows.Forms;

namespace app4bybit_2
{
    public static class ThemeManager
    {
        public static void ApplyTheme(Form form)
        {
            string savedTheme = Properties.Settings.Default.Theme;

            if (savedTheme == "Dark")
                ApplyDarkTheme(form);
            else
                ApplyLightTheme(form);
        }

        public static void ApplyDarkTheme(Form form)
        {
            form.BackColor = Color.FromArgb(0, 0, 64);
        }

        public static void ApplyLightTheme(Form form)
        {
            form.BackColor = Color.FloralWhite;
        }

        public static void SaveTheme(string theme)
        {
            Properties.Settings.Default.Theme = theme;
            Properties.Settings.Default.Save();
        }
    }
}