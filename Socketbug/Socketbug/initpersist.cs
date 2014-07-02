
using System.Threading.Tasks;

using System.Windows.Media.Imaging;
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

using System.IO;



namespace Socketbug
{
    class initpersist
    {
       
       
       public static void pic_DownloadStringCompleted(string e)
        {
            string downl = e;

            XmlReader real = XmlReader.Create(new System.IO.StringReader(downl));
            /* string vall = e.Result;
             //MessageBox.Show(vall) ;
           
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
            if (img == "http://static.dnaindia.com/images/710/logo_dna_rss.gif")
            {
                img = "https://lh3.googleusercontent.com/-dBbFPJ6cFTE/UeQtvexeJTI/AAAAAAAACrw/oyJ-TCvR9I0/s426/picture043.jpg";
            }


            BitmapImage backer = new BitmapImage();
            backer.UriSource = new Uri(img);
            Image sampler = new Image();
            sampler.Source = backer;
           // backgroundpoll.ImageSource = sampler.Source;
            persist.Writepersist("txt", "pic_data", downl);

        }

        void pic_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

        }
        public static void read_tech_DownloadStringCompleted(string e)
        {
            string polll = App.appsettings.persist_load<string>("polls");
            int poll = Convert.ToInt32(polll);
            App.tech.Clear();
            string downl = e;
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
                    img = "https://lh3.googleusercontent.com/-dBbFPJ6cFTE/UeQtvexeJTI/AAAAAAAACrw/oyJ-TCvR9I0/s426/picture043.jpg";
                }


                App.tech.Add(new headlines(i.ToString(), tit, img, des, "sam"));
                persist.Writepersist("txt", "tech_data.dat", downl);
            }
        }
        void refme(object sender, RoutedEventArgs e)
        {
            
        }
        void read_tech_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

       public static void read_india_DownloadStringCompleted(string e)
        {
            string polll = App.appsettings.persist_load<string>("polls");
            int poll = Convert.ToInt32(polll);
            App.india.Clear();
            string downl = e;
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
                    img = "https://lh3.googleusercontent.com/-dBbFPJ6cFTE/UeQtvexeJTI/AAAAAAAACrw/oyJ-TCvR9I0/s426/picture043.jpg";
                }


                App.india.Add(new headlines(i.ToString(), tit, img, des, "sam"));
                persist.Writepersist("txt", "india_data.dat", downl);
            }
        }

       public static void read_india_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //    throw new NotImplementedException();
        }

       public static void read_cricket_DownloadStringCompleted(string e)
        {
            string polll = App.appsettings.persist_load<string>("polls");
            int poll = Convert.ToInt32(polll);
            App.cricket.Clear();
            string downl = e;
            MessageBox.Show(downl);
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
                    img = "https://lh3.googleusercontent.com/-dBbFPJ6cFTE/UeQtvexeJTI/AAAAAAAACrw/oyJ-TCvR9I0/s426/picture043.jpg";
                }

                App.cricket.Add(new headlines(i.ToString(), tit, img, des, "sam"));
              //  persist.Writepersist("txt", "cric_data.dat", downl);

            }
        }

        public static void read_cricket_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

        }

        public static void read_world_DownloadStringCompleted(string e)
        {
            //dna data
            string polll = App.appsettings.persist_load<string>("polls");
            int poll = Convert.ToInt32(polll);
            App.newsfeed.Clear();
            string downl = e;
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
              //  real.MoveToAttribute(0);
                real.ReadAttributeValue();
                string img = real.Value;
                if (img == "http://static.dnaindia.com/images/710/logo_dna_rss.gif")
                {
                    img = "https://lh3.googleusercontent.com/-dBbFPJ6cFTE/UeQtvexeJTI/AAAAAAAACrw/oyJ-TCvR9I0/s426/picture043.jpg";
                }

                App.newsfeed.Add(new headlines(i.ToString(), tit, img, des, "sam"));
              //  persist.Writepersist("txt", "newsfeed_data.dat", downl);

            }

        }

        private void read_world_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //un handeled in this version
        }

        public static void read_DownloadStringCompleted(string e)
        {
            try
            {
                string polll = App.appsettings.persist_load<string>("polls");
                int poll = Convert.ToInt32(polll);
                App.world.Clear();
                string downl = e;
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
                  //  persist.Writepersist("txt", "world_data.dat", downl);

                }
            }
            catch (System.Reflection.TargetInvocationException h)
            {


            }


        }
    }
}
