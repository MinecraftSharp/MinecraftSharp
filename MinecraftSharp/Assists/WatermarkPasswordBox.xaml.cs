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

namespace MinecraftSharp.Assists
{
    /// <summary>
    /// Interaction logic for WatermarkPasswordBox.xaml
    /// </summary>
    public partial class WatermarkPasswordBox : UserControl
    {
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register
            (
                 "Watermark",
                 typeof(string),
                 typeof(WatermarkPasswordBox),
                 new PropertyMetadata(string.Empty)
            );

        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public WatermarkPasswordBox()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void WaterTextbox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (WaterTextbox.Password.Length > 0)
            {
                var fadeLabelOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.1));
                HintLabel.BeginAnimation(Label.OpacityProperty, fadeLabelOutAnimation);
            }
            else
            {
                var fadeLabelInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.1));
                HintLabel.BeginAnimation(Label.OpacityProperty, fadeLabelInAnimation);
            }
        }
    }
}