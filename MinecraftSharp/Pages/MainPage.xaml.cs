using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinecraftSharp.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Logic.SecondaryGrid = MainControl;
            HideHeader();
        }
        private void HeaderTriggerGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            ShowHeader();
            ShrinkMainGrid();
        }

        private void HeaderGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            HideHeader();
            GrowGrid();
        }
        private void ShowHeader()
        {
            var moveAnimation = new ThicknessAnimation(new Thickness(0, 30, 0, 0), TimeSpan.FromSeconds(0.25));
            HeaderGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);

            var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            TrianglePoly.BeginAnimation(Polygon.OpacityProperty, fadeOutAnimation);
        }

        private void HideHeader()
        {
            var moveAnimation = new ThicknessAnimation(new Thickness(0, -60, 0, 0), TimeSpan.FromSeconds(0.25));
            HeaderGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);

            var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
            TrianglePoly.BeginAnimation(Polygon.OpacityProperty, fadeInAnimation);
        }
        private void ShrinkMainGrid()
        {
            var moveAnimation = new ThicknessAnimation(new Thickness(0, 125, 0, 0), TimeSpan.FromSeconds(0.25));
            MainGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);
        }
        private void GrowGrid()
        {
            var moveAnimation = new ThicknessAnimation(new Thickness(0, 35, 0, 0), TimeSpan.FromSeconds(0.25));
            MainGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logic.Overlay<ManageAccountsPage>();
        }
    }
}
