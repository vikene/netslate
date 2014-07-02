using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
namespace Socketbug
{
    public partial class settings : PhoneApplicationPage
    {
        public settings()
        {
            InitializeComponent();
            string n = App.appsettings.persist_load<string>("polls");
            slide.Value = Convert.ToInt32(n);
            string p = App.appsettings.persist_load<string>("background");
            if (p == "true")
            {
                Back.IsChecked = true;
            }
            else
            {
                Back.IsChecked = false;
            }
            
        }

        private void slide_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            {
                
            
                double i = 0;
                i = Math.Round(slide.Value);
                valuee.Text = i.ToString();
            }

        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            string pollcount = valuee.Text;
            if (pollcount != null && pollcount != "0")
            {
                App.appsettings.save("polls", pollcount);
            }
            if (Back.IsChecked == true)
            {
                App.appsettings.save("background", "true");
            }
            if (Back.IsChecked == false)
            {
                App.appsettings.save("background", "false");
            }
           
        }




        /*experimentted codes :) ... got out put at 2.52 10/02/2013 
         * author Vigneash Sundar 
         * thanks to online refernces .. 
         * 
         * private void wrte()
           {
               IsolatedStorageFile stoe = IsolatedStorageFile.GetUserStoreForApplication();
               string j = "helloe";
               StreamWriter nee = new StreamWriter (new IsolatedStorageFileStream("bba.txt", FileMode.Append, stoe));
                nee.Write(j);
                nee.Close();

           }
           private void red()
           {
               IsolatedStorageFile ss = IsolatedStorageFile.GetUserStoreForApplication();
               StreamReader hh = new StreamReader(new IsolatedStorageFileStream("bba.txt", FileMode.Open, ss));
               string bab = hh.ReadToEnd();
               MessageBox.Show(bab);
               hh.Close();
           }

           private async Task WriteToFile()
           {
               string dd = "hey checking on you buddy ";
               byte[] sampledata = System.Text.Encoding.UTF8.GetBytes( dd.ToCharArray());
               StorageFolder localfolder = Windows.Storage.ApplicationData.Current.LocalFolder;
               var datafolder = await localfolder.CreateFolderAsync("sample", CreationCollisionOption.ReplaceExisting);
               var file = await datafolder.CreateFileAsync("samplee.txt");
               using ( var s = await file.OpenStreamForWriteAsync())

               {
                   s.Write(sampledata, 0, 20);
                   MessageBox.Show("writting");

                   s.Close();
               }
               MessageBox.Show("written");

           }
           private async Task ReadFromFile()
           {
               string jj = null;
               StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
               if (local != null)
               {

                   var folder = await local.GetFolderAsync("sample");
                   var file = await folder.OpenStreamForReadAsync("sample.txt");
                   if (file != null)
                   {
                       MessageBox.Show("found");
                       using (StreamReader read = new StreamReader(file))
                       {
                           jj = read.ReadToEnd();
                           read.Close();
                       }
                       MessageBox.Show(jj);
                   }
               }
           }

           private async void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
           {
             await  WriteToFile();
             sett();
              // wrte();
           }
           private async void app(object sender, EventArgs e)
           {

           }

           private async void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
           {
               string h = "somekey";
             string j=   LoadPersistent<string>(h);
             MessageBox.Show(j);
             //  red();
           }
           public void sett()
           {
               IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

               settings["somekey"] = "myvalue";
               settings["otherkey"] = true;

               settings.Save();
           }
           public static bool ClearPersistent(string key)
           {
               if (null == key)
                   return false;

               var store = IsolatedStorageSettings.ApplicationSettings;
               if (store.Contains(key))
                   store.Remove(key);
               store.Save();
               return true;
           }

           public static bool SavePersistent(string key, object value)
           {
               if (null == value)
                   return false;

               var store = IsolatedStorageSettings.ApplicationSettings;
               if (store.Contains(key))
                   store[key] = value;
               else
                   store.Add(key, value);

               store.Save();
               return true;
           }

           public static T LoadPersistent<T>(string key)
           {
               var store = IsolatedStorageSettings.ApplicationSettings;
               if (!store.Contains(key))
                   return default(T);

               return (T)store[key];
           }*/
    }
}
