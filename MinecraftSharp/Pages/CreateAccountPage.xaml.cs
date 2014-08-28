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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinecraftSharp.Pages
{
    /// <summary>
    /// Interaction logic for CreateAccountPage.xaml
    /// </summary>
    public partial class CreateAccountPage : Page
    {
        public CreateAccountPage()
        {
            InitializeComponent();
            Username.WaterTextbox.TextChanged += Username_TextChanged;
            Password.WaterTextbox.PasswordChanged += Password_TextChanged;
            EnterButton.Visibility = Visibility.Hidden;
            EnterButton.IsEnabled = false;
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Username.WaterTextbox.Text.Length != 0)
            {
                if (Password.WaterTextbox.Password.Length != 0)
                {
                    EnterButton.Visibility = Visibility.Visible;
                    LoginButton.IsEnabled = true;
                }
                else
                {
                    EnterButton.Visibility = Visibility.Hidden;
                    EnterButton.IsEnabled = false;
                }
            }
            else
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
            if (Username.WaterTextbox.Text.Length == 0)
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
            if (Password.WaterTextbox.Password.Length == 0)
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
        }

        private void Password_TextChanged(object sender, RoutedEventArgs e)
        {
            if (Username.WaterTextbox.Text.Length != 0)
            {
                if (Password.WaterTextbox.Password.Length != 0)
                {
                    EnterButton.Visibility = Visibility.Visible;
                    LoginButton.IsEnabled = true;
                }
                else
                {
                    EnterButton.Visibility = Visibility.Hidden;
                    EnterButton.IsEnabled = false;
                }
            }
            else
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
            if (Username.WaterTextbox.Text.Length == 0)
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
            if (Password.WaterTextbox.Password.Length == 0)
            {
                EnterButton.Visibility = Visibility.Hidden;
                EnterButton.IsEnabled = false;
            }
        }

        private void LoginHandler(object sender, RoutedEventArgs e)
        {
            if (Username.WaterTextbox.Text.Length != 0 && Password.WaterTextbox.Password.Length != 0)
            {
                string User = Username.WaterTextbox.Text;
                string Pass = Password.WaterTextbox.Password;
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(User + "!~Rexdec~!" + Pass);
                byte[] hash = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                var UserPassFile = File.Create(System.IO.Path.Combine(Logic.ExecutingDirectory, "Assists", "MCSharpLogin.MD5"));
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                UserPassFile.Write(hash, 0, hash.Length);
                Logic.SwichMaserPage<MainPage>();
            }
        }

    }
}
