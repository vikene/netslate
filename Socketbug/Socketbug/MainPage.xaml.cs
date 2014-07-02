using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml;
using Microsoft.Phone.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Windows.Media.Imaging;
using System.IO;

namespace Socketbug
{
    public partial class MainPage : PhoneApplicationPage
    {
        WebClient read;
        WebClient read_world;
        WebClient read_cricket;
        WebClient read_india;
        WebClient read_tech;
        WebClient pic;
        WebClient expero;
        WebClient custom;
        int poll = 0;
        string background = "same";
        ShellTile primary = ShellTile.ActiveTiles.First();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            string pol = "polls";
            string pole = App.appsettings.persist_load<string>(pol);
            poll = Convert.ToInt32(pole);
            string bac = "background";
            background = App.appsettings.persist_load<string>(bac);


            top_stories.ItemsSource = App.newsfeed;
            world.ItemsSource = App.world;
            crickete.ItemsSource = App.cricket;
            ind.ItemsSource = App.india;
            tech.ItemsSource = App.tech;
            if (DeviceNetworkInformation.IsNetworkAvailable == true)
            {
                if (DeviceNetworkInformation.IsCellularDataEnabled == true)
                {
                    if (DeviceNetworkInformation.IsCellularDataRoamingEnabled == true)
                    {
                        string msg = "Your in Roaming, Roaming Charges May apply";
                        MessageBox.Show(msg);
                    }
                    updateme();
                }
                else
                {
                    string nope = "Network is Currently Unavailable .. ";
                    MessageBox.Show(nope);
                }
            }
            // Set the data context of the listbox control to the sample data
            
 
        }

        public void updateme()
        {
            read = new WebClient();
            read.DownloadProgressChanged += read_DownloadProgressChanged;
            read.DownloadStringCompleted += read_DownloadStringCompleted;
            read.DownloadStringAsync(new Uri("http://feeds.bbci.co.uk/news/rss.xml"));
            read_world = new WebClient();
            read_world.DownloadProgressChanged +=read_world_DownloadProgressChanged;
            read_world.DownloadStringCompleted += read_world_DownloadStringCompleted;
            read_world.DownloadStringAsync(new Uri("http://www.dnaindia.com/services/rss/news-latest.xml"));
            read_cricket = new WebClient();
            read_cricket.DownloadProgressChanged += read_cricket_DownloadProgressChanged;
            read_cricket.DownloadStringCompleted += read_cricket_DownloadStringCompleted;
            read_cricket.DownloadStringAsync(new Uri("http://www.dnaindia.com/syndication/rss,catid-6.xml"));
            read_india = new WebClient();
            read_india.DownloadProgressChanged += read_india_DownloadProgressChanged;
            read_india.DownloadStringCompleted += read_india_DownloadStringCompleted;
            read_india.DownloadStringAsync(new Uri("http://www.dnaindia.com/syndication/rss,catid-2.xml"));
            read_tech = new WebClient();
            read_tech.DownloadProgressChanged += read_tech_DownloadProgressChanged;
            read_tech.DownloadStringCompleted += read_tech_DownloadStringCompleted;
            read_tech.DownloadStringAsync(new Uri("http://www.dnaindia.com/syndication/rss,catid-5.xml"));
            custom = new WebClient();
            custom.DownloadStringCompleted += custom_DownloadStringCompleted;
            custom.DownloadStringAsync(new Uri("http://workingbackend.yolasite.com/resources/same.xml"));
            custom.DownloadProgressChanged += custom_DownloadProgressChanged;
            if (background == "true")
            {
                pic = new WebClient();
                pic.DownloadProgressChanged += pic_DownloadProgressChanged;
                pic.DownloadStringCompleted += pic_DownloadStringCompleted;
                pic.DownloadStringAsync(new Uri("http://www.dnaindia.com/services/rss/news-latest.xml"));
                // pic.DownloadStringAsync(new Uri("http://vigneashsundar.in/rss"));
                //  expero = new WebClient();
                //expero.DownloadStringCompleted += expero_DownloadStringCompleted;
                //expero.AllowReadStreamBuffering = true;
                //expero.DownloadStringAsync(new Uri("http://socketbug.tumblr.com/rss"));
            }
        }

        void custom_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
          //  throw new NotImplementedException();
        }

        void custom_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            //MessageBox.Show(downl);
        }

      /*  void expero_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string ss = e.Result;
            MessageBox.Show(ss);
            XmlReader jj = XmlReader.Create(new System.IO.StringReader(ss));
            jj.ReadToFollowing("item");
            jj.ReadToFollowing("title");
            // jj.ReadToFollowing("description");
            jj.Read();
            string check = jj.Value;
            MessageBox.Show(check);
        }*/
        


        void pic_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    string downl = e.Result;
                   // MessageBox.Show(downl);
                    
                      XmlReader real = XmlReader.Create(new System.IO.StringReader(downl));
                     /* string vall = e.Result;
                      //MessageBox.Show(vall);
           
                      XmlReader jj = XmlReader.Create(new System.IO.StringReader(vall));
                      jj.ReadToFollowing("item");
                      jj.ReadToFollowing("title");
                     // jj.ReadToFollowing("description");
                      jj.Read();
                      string check = jj.Value;
                     // MessageBox.Show(check);
                      jj.ReadToFollowing("media:thumbnail");
                      jj.ReadToFollowing("media:thumbnail");
                      jj.MoveToAttribute(2);
                      jj.ReadAttributeValue();
                      string img = jj.Value;
                      //MessageBox.Show(img);*/
                    
    real.ReadToFollowing("item");
    real.ReadToFollowing("title");
    real.Read();
    string tit;
    tit = real.Value;
    real.ReadToFollowing("description");
    real.Read();
    string des;
    des = real.Value;
    real.ReadToFollowing("enclosure");
    real.MoveToAttribute(0);
    real.ReadAttributeValue();
    string img = real.Value;
    StandardTileData javs = new StandardTileData();
    for (; img == "http://static.dnaindia.com/images/710/logo_dna_rss.gif"; )
    {

        

            real.ReadToFollowing("enclosure");
            real.MoveToAttribute(0);
            real.ReadAttributeValue();
            img = real.Value;


        
    }

    BitmapImage backer = new BitmapImage();
    backer.UriSource = new Uri(img);
    Image sampler = new Image();
    sampler.Source = backer;
    backgroundpoll.ImageSource = sampler.Source;
    javs.BackgroundImage = new Uri(img);
    javs.Title = "News Reader";
    javs.BackTitle = "Just Now !!";
    javs.BackContent = tit;
  
    if (primary != null)
    {
        primary.Update(javs);
        
    }


    
                }
            }
        }

        void pic_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
        }
        void read_tech_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error==null&& e.Result != null)
            {
                App.tech.Clear();
                string downl = e.Result;
                XmlReader real = XmlReader.Create(new System.IO.StringReader(downl));
                int i = 0;
                for (; i < poll; i++)
                {
                    real.ReadToFollowing("item");
                    real.ReadToFollowing("title");
                    real.Read();
                    string tit;
                    tit = real.Value;
                    real.ReadToFollowing("description");
                    real.Read();
                    string des;
                    des = real.Value;
                    real.ReadToFollowing("enclosure");
                    real.MoveToAttribute(0);
                    real.ReadAttributeValue();
                    string img = real.Value;
                    if (img == "http://static.dnaindia.com/images/710/logo_dna_rss.gif")
                    {
                        img = "http://workingbackend.yolasite.com/resources/question.png";
                    }


                    App.tech.Add(new headlines(i.ToString(), tit, img, des, "sam"));
                    persist.Writepersist("txt", "tech_data.dat", downl);
                }
            }
        }
        void refme(object sender, RoutedEventArgs e)
        {
            updateme();
        }
        void read_tech_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void read_india_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && e.Result != null)
            {
                App.india.Clear();
                string downl = e.Result;
                XmlReader real = XmlReader.Create(new System.IO.StringReader(downl));
                int i = 0;
                for (; i < poll; i++)
                {
                    real.ReadToFollowing("item");
                    real.ReadToFollowing("title");
                    real.Read();
                    string tit;
                    tit = real.Value;
                    real.ReadToFollowing("description");
                    real.Read();
                    string des;
                    des = real.Value;
                    real.ReadToFollowing("enclosure");
                    real.MoveToAttribute(0);
                    real.ReadAttributeValue();
                    string img = real.Value;
                    if (img == "http://static.dnaindia.com/images/710/logo_dna_rss.gif")
                    {
                        img = "http://workingbackend.yolasite.com/resources/question.png";
                    }


                    App.india.Add(new headlines(i.ToString(), tit, img, des, "sam"));
                    persist.Writepersist("txt", "india_data.dat", downl);
                }
            }
        }

        void read_india_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
        //    throw new NotImplementedException();
        }

        void read_cricket_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && e.Result != null)
            {
                App.cricket.Clear();
                string downl = e.Result;
                // MessageBox.Show(downl);
                XmlReader real = XmlReader.Create(new System.IO.StringReader(downl));
                int i = 0;
                for (; i < poll; i++)
                {
                    real.ReadToFollowing("item");
                    real.ReadToFollowing("title");
                    real.Read();
                    string tit;
                    tit = real.Value;
                    real.ReadToFollowing("description");
                    real.Read();
                    string des;
                    des = real.Value;
                    real.ReadToFollowing("enclosure");
                    real.MoveToAttribute(0);
                    real.ReadAttributeValue();
                    string img = real.Value;
                    if (img == "http://static.dnaindia.com/images/710/logo_dna_rss.gif")
                    {
                        img = "http://workingbackend.yolasite.com/resources/question.png";
                    }

                    App.cricket.Add(new headlines(i.ToString(), tit, img, des, "sam"));
                    persist.Writepersist("txt", "cric_data.dat", downl);

                }
            }
        }

        void read_cricket_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
           
        }

        void read_world_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //dna data
            if (e.Error == null && e.Result != null)
            {
                App.newsfeed.Clear();
                string downl = e.Result;
                XmlReader real = XmlReader.Create(new System.IO.StringReader(downl));
                int i = 0;
                for (; i < poll; i++)
                {
                    real.ReadToFollowing("item");
                    real.ReadToFollowing("title");
                    real.Read();
                    string tit;
                    tit = real.Value;
                    real.ReadToFollowing("description");
                    real.Read();
                    string des;
                    des = real.Value;
                    real.ReadToFollowing("enclosure");
                    real.MoveToAttribute(0);
                    real.ReadAttributeValue();
                    string img = real.Value;
                    if (img == "http://static.dnaindia.com/images/710/logo_dna_rss.gif")
                    {
                        img = "http://workingbackend.yolasite.com/resources/question.png";
                    }

                    App.newsfeed.Add(new headlines(i.ToString(), tit, img, des, "sam"));
                    persist.Writepersist("txt", "newsfeed_data.dat", downl);

                }

            }
        }

        private void read_world_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //un handeled in this version
        }

        void read_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && e.Result != null)
            {
                try
                {
                    App.world.Clear();
                    string downl = e.Result;
                    XmlReader real = XmlReader.Create(new System.IO.StringReader(downl));
                    int i = 0;
                    for (; i < poll; i++)
                    {
                        real.ReadToFollowing("item");
                        real.ReadToFollowing("title");
                        real.Read();
                        string tit;
                        tit = real.Value;
                        real.ReadToFollowing("description");
                        real.Read();
                        string des;
                        des = real.Value;
                        real.ReadToFollowing("media:thumbnail");
                        real.MoveToAttribute(2);
                        real.ReadAttributeValue();
                        string img = real.Value;
                        App.world.Add(new headlines(i.ToString(), tit, img, des, "sam"));
                        persist.Writepersist("txt", "world_data.dat", downl);

                    }
                }
                catch (System.Reflection.TargetInvocationException h)
                {


                }


            }
        }

        public static void anne()
        { 
            
        }
        void read_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
        }
        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Credits.xaml", UriKind.Relative));
        }

        private void top_stories_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int i = top_stories.SelectedIndex;
            
            string urll = "/fullread.xaml?pid=1&sid=" + i;

            NavigationService.Navigate(new Uri(urll, UriKind.Relative));

            top_stories.SelectedIndex = -1;
        }
        private void ind_selection(object sender, SelectionChangedEventArgs e)
        {
            int i = ind.SelectedIndex;

            string urll = "/fullread.xaml?pid=3&sid=" + i;

            NavigationService.Navigate(new Uri(urll, UriKind.Relative));

            ind.SelectedIndex = -1;
 
        }
        private void tech_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int i = tech.SelectedIndex;

            string urll = "/fullread.xaml?pid=5&sid=" + i;

            NavigationService.Navigate(new Uri(urll, UriKind.Relative));

            tech.SelectedIndex = -1;
        }

        private void crickete_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int i = crickete.SelectedIndex;

            string urll = "/fullread.xaml?pid=4&sid=" + i;

            NavigationService.Navigate(new Uri(urll, UriKind.Relative));

            crickete.SelectedIndex = -1;

        }

        private void world_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int i = world.SelectedIndex;

            string urll = "/fullread.xaml?pid=2&sid=" + i;

            NavigationService.Navigate(new Uri(urll, UriKind.Relative));

            world.SelectedIndex = -1;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            updateme();
        }
        private void event_han1(object sender, EventArgs e)
        {
            string urll = "/settings.xaml";
            NavigationService.Navigate(new Uri(urll, UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Credits.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click_3(object sender, EventArgs e)
        {
            
            updateme();
        }
    }
}