using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;

namespace GoodHousekeeping
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void OnLogin(object sender, RoutedEventArgs e)
        {
            var md5 = MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Username.Text + "," + Password.Password);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            foreach (byte t in hash)
            {
                var hexString = t.ToString("X");
                sb.Append((hexString.Length % 2 == 0 ? "" : "0") + hexString);
            }
            try
            {
                var login = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "login.pwd");
                if (login.ToLower() == sb.ToString().ToLower())
                {
                    var mw = new MainWindow();
                    mw.Show();
                    Hide();
                }
                else
                {
                    await this.ShowMessageAsync("Failed to login", "Invalid credentials");
                    return;
                }

            }
            catch
            {
            }
            await this.ShowMessageAsync("Failed to login", "Bad login file.");
        }

    }
}
