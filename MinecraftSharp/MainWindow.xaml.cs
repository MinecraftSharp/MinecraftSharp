using MinecraftSharp.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace MinecraftSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logic.MainGrid = MainContent;
            Logic.ExecutingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Logic.OverlayGrid = OverlayContent;
            if (!Directory.Exists(Path.Combine(Logic.ExecutingDirectory, "Assists")))
            {
                Directory.CreateDirectory(Path.Combine(Logic.ExecutingDirectory, "Assists"));
                var Account = File.Create(Path.Combine(Logic.ExecutingDirectory, "Assists", "Accounts.Encrypted"));

                Logic.SwichMaserPage<CreateAccountPage>();
            }
            else
            {
                if (!File.Exists(Path.Combine(Logic.ExecutingDirectory, "Assists", "MCSharpLogin.MD5")))
                {
                    Logic.SwichMaserPage<CreateAccountPage>();
                }
                else
                {
                    Logic.SwichMaserPage<LoginToAccountPage>();
                }
            }
            //Logic.SwichMaserPage<MainPage>();
        }
    }
}
