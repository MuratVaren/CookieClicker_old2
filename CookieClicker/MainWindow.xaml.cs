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

namespace CookieClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private decimal cookieCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
            LblCookieCounter.Content = 0;
        }

        private void ImgCookie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("Assets/Images/Cookie_Cute.png",UriKind.RelativeOrAbsolute));
                ImgCookie.Source = bitmapImage;
                ThicknessAnimation clickAnimation = new ThicknessAnimation()
                {
                    To = new Thickness(15),
                    Duration = TimeSpan.FromMilliseconds(115),
                    FillBehavior = FillBehavior.Stop,
                };
                clickAnimation.Completed += ClickAnimation_Completed;

                cookieCounter++;
                ImgCookie.BeginAnimation(Image.MarginProperty, clickAnimation);
                UpdateCookieDisplay();
                ButtonEnabler();
            }
        }
        private void ClickAnimation_Completed(object sender, EventArgs e)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri("Assets/Images/Cookie.png", UriKind.RelativeOrAbsolute));
            ImgCookie.Source = bitmapImage;
        }
        public void UpdateCookieDisplay()
        {
            LblCookieCounter.Content = $"{cookieCounter} Cookies";
            this.Title = $"{cookieCounter} Cookies";
        }

        public void ButtonEnabler()
        {
            BtnPointer.IsEnabled = cookieCounter >= 15;
            BtnGranny.IsEnabled = cookieCounter >= 100;
            BtnFarm.IsEnabled = cookieCounter >= 1100;
            BtnMine.IsEnabled = cookieCounter >= 12000;
            
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
