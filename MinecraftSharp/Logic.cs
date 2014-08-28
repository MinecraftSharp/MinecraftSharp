using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MinecraftSharp
{
    public class Logic
    {
        internal static ContentControl MainGrid;
        internal static ContentControl SecondaryGrid;
        internal static ContentControl OverlayGrid;
        internal static MainWindow Win;
        internal static String ExecutingDirectory;
        internal static Type CurrentPage;

        internal static void SwichMaserPage<T>(bool Fade = true, params object[] Arguments)
        {
            if (CurrentPage == typeof(T))
                return;

            Page instance = (Page)Activator.CreateInstance(typeof(T), Arguments);
            CurrentPage = typeof(T);

            if (Fade)
            {
                var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
                fadeOutAnimation.Completed += (x, y) =>
                {
                    MainGrid.Content = instance.Content;
                    var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
                    MainGrid.BeginAnimation(ContentControl.OpacityProperty, fadeInAnimation);
                };
                MainGrid.BeginAnimation(ContentControl.OpacityProperty, fadeOutAnimation);
            }
            else
            {
                 MainGrid.Content = instance.Content;
            }
        }
        internal static void SwichPage<T>(bool Fade = false, params object[] Arguments)
        {
            if (CurrentPage == typeof(T))
                return;

            Page instance = (Page)Activator.CreateInstance(typeof(T), Arguments);
            CurrentPage = typeof(T);

            if (Fade)
            {
                var fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
                fadeOutAnimation.Completed += (x, y) =>
                {
                    SecondaryGrid.Content = instance.Content;
                    var fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.25));
                    SecondaryGrid.BeginAnimation(ContentControl.OpacityProperty, fadeInAnimation);
                };
                SecondaryGrid.BeginAnimation(ContentControl.OpacityProperty, fadeOutAnimation);
            }
            else
            {
                SecondaryGrid.Content = instance.Content;
            }
        }

        internal static void Overlay<T>(params object[] Arguments)
        {
            var moveAnimation = new ThicknessAnimation(new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(0.5));
            OverlayGrid.Margin = new Thickness(1357, 0, -1357, 0);
            Page instance = (Page)Activator.CreateInstance(typeof(T), Arguments);
            OverlayGrid.Content = instance.Content;
            OverlayGrid.Visibility = Visibility.Visible;
            OverlayGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);
        }
        internal static void HideOverlay()
        {
            var moveAnimation = new ThicknessAnimation(new Thickness(2000, 0, -2000, 0), TimeSpan.FromSeconds(0.5));
            OverlayGrid.BeginAnimation(Grid.MarginProperty, moveAnimation);
        }

        public static void FocusWindow()
        {
            Win.Focus();
        }
    }
}
