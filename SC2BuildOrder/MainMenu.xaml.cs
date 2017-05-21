using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;


namespace SC2BuildOrder
{
    public partial class MainMenu : PhoneApplicationPage
    {
        String mTo;
        String mRace;
        public MainMenu()
        {
            InitializeComponent();

        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            RaceDialog.Visibility = Visibility.Collapsed;
            PageTitle.Visibility = Visibility.Visible;
            Random rand = new Random();
            int n = rand.Next(1,50);
            //if (n > 5)
            //{
            //    pagetitle.text = " ";
            //}
            //else
            //{
            //    pagetitle.text = "sc2 build orders";
            //}
            String bgpath = "/Images/Backgrounds/bg" + n + ".jpg/";
            BitmapImage bitmapImage = new BitmapImage(new Uri(bgpath, UriKind.Relative));
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = bitmapImage;
            LayoutRoot.Background = imageBrush;

            // work around
            RaceDialog.Visibility = Visibility.Visible;
            PageTitle.Visibility = Visibility.Collapsed;
            mTo = "CounterUnits";
        }
  



        private void Back_Click(object sender, RoutedEventArgs e)
        {
            RaceDialog.Visibility = Visibility.Collapsed;
            PageTitle.Visibility = Visibility.Visible;
        }

        private void Terran_Click(object sender, RoutedEventArgs e)
        {
            mRace = "Terran";
            gotoPage();
        }

        private void Zerg_Click(object sender, RoutedEventArgs e)
        {
            mRace = "Zerg";
            gotoPage();
        }

        private void Protoss_Click(object sender, RoutedEventArgs e)
        {
            mRace = "Protoss";
            gotoPage();
        }
        private void gotoPage()
        {
            String path = "/" + mTo + ".xaml?race=" + mRace;
            NavigationService.Navigate(new Uri(path, UriKind.RelativeOrAbsolute));
        }


        private void CounterUnits_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            RaceDialog.Visibility = Visibility.Visible;
            PageTitle.Visibility = Visibility.Collapsed;
            mTo = "CounterUnits";
        }



        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/InfoPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}