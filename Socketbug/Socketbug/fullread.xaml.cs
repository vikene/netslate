using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace Socketbug
{
    public partial class fullread : PhoneApplicationPage
    {
        public fullread()
        {
            InitializeComponent();
               
        }
        string parser1 = string.Empty;
        string parser2 = string.Empty;
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            parser1 = NavigationContext.QueryString["pid"];
            if (parser1 == "1")
            {
               // MessageBox.Show("Youre from the top stories column");
            }
            
            parser2 = NavigationContext.QueryString["sid"];
            //MessageBox.Show(parser2);
            initrun();
            
        }
        private void initrun()
        {
            if (parser1 == "1")
            {
                var q = App.newsfeed.Where(X => X.Id == parser2).First();
                string header = q.Headline;
                head.Text = header;
                string url = q.Imageuri;
                string des = q.Description;
                newse.Text = des;
                Uri je = (new Uri(q.Imageuri));
                BitmapImage nee = new BitmapImage(je);
                Image my = new Image();
                my.Source = nee;
               // imge.Source = my.Source;
                backgroundpoll.ImageSource = my.Source;
            }

            if (parser1 == "2")
            {
                var q = App.world.Where(X => X.Id == parser2).First();
                string header = q.Headline;
                head.Text = header;
                string url = q.Imageuri;
                string des = q.Description;
                newse.Text = des;
                Uri je = (new Uri(q.Imageuri));
                BitmapImage nee = new BitmapImage(je);
                Image my = new Image();
                my.Source = nee;
               // imge.Source = my.Source;
                backgroundpoll.ImageSource = my.Source;
            }
            if (parser1 == "3")
            {
                var q = App.india.Where(X => X.Id == parser2).First();
                string header = q.Headline;
                head.Text = header;
                string url = q.Imageuri;
                string des = q.Description;
                newse.Text = des;
                Uri je = (new Uri(q.Imageuri));
                BitmapImage nee = new BitmapImage(je);
                Image my = new Image();
                my.Source = nee;
               // imge.Source = my.Source;
                backgroundpoll.ImageSource = my.Source;
            }
            if (parser1 == "4")
            {
                var q = App.cricket.Where(X => X.Id == parser2).First();
                string header = q.Headline;
                head.Text = header;
                string url = q.Imageuri;
                string des = q.Description;
                newse.Text = des;
                Uri je = (new Uri(q.Imageuri));
                BitmapImage nee = new BitmapImage(je);
                Image my = new Image();
                my.Source = nee;
               // imge.Source = my.Source;
                backgroundpoll.ImageSource = my.Source;
            }
            if (parser1 == "5")
            {
                var q = App.tech.Where(X => X.Id == parser2).First();
                string header = q.Headline;
                head.Text = header;
                string url = q.Imageuri;
                string des = q.Description;
                newse.Text = des;
                Uri je = (new Uri(q.Imageuri));
                BitmapImage nee = new BitmapImage(je);
                Image my = new Image();
                my.Source = nee;
               // imge.Source = my.Source;
                backgroundpoll.ImageSource = my.Source;
            }
           
        }
        public void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            string parser1 = string.Empty;
            parser1 = NavigationContext.QueryString["pid"];
            if (parser1 == "1")
            {
               // MessageBox.Show("Youre from the top stories column");
            }
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/settings.xaml",UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Credits.xaml",UriKind.Relative));
        }
        
    }
  
}