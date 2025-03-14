using System;

namespace app4bybit
{
    public static class ThemeManager
    {
        public static void ApplyTheme(Form form)
        {
            string savedTheme = Properties.Settings.Default.Theme;

            if (savedTheme == "Dark")
            {
                ApplyDarkTheme(form);
            }
            else
            {
                ApplyLightTheme(form);
            }
        }

        private static void ApplyDarkTheme(Form form)
        {
            form.BackColor = Color.FromArgb(0, 0, 64); // Тёмный фон
            form.ForeColor = Color.White; // Белый текст
        }

        private static void ApplyLightTheme(Form form)
        {
            form.BackColor = Color.White; // Белый фон
            form.ForeColor = Color.Black; // Чёрный текст
        }

        public static void SaveTheme(string theme)
        {
            Properties.Settings.Default.Theme = theme;
            Properties.Settings.Default.Save();
        }
    }
}