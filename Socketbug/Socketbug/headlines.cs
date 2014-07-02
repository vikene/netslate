// Copy Right Vigneash Sundar 
// vigneashsundar@live.com , Www.vigneashsundar.in

// this contains MVVM code 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Socketbug
{
    public class headlines : INotifyPropertyChanged
    {
        private string headline;
        private string imageuri;
        private string description;
        private string link;
        private string id;

        // accessor properties 
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                id = Id;
                NotifyPropertyChanged("id");
            }
        }
        public string Headline
        {
            get {
                return this.headline;
            }
            set {
                headline = Headline;
                NotifyPropertyChanged("headline");
            }
        }
        public string Imageuri
        {
            get { 
                return this.imageuri;
            }
            set{
                imageuri = Imageuri;
                NotifyPropertyChanged("imageuri");
            }
                
        }
        public string Description
        {
            get {
                return this.description;
            }
            set
            {
                description = Description;
                NotifyPropertyChanged("description");
            }
        }
        public string Link
        {
            get {
                return this.link;
            }
            set
            {
                link = Link;
                NotifyPropertyChanged("link");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public headlines() { }

        public headlines(string i,string head, string image, string des, string llink)
        {
            id = i;
            headline = head;
            imageuri = image;
            description = des;
            link = llink;
        }

        private void NotifyPropertyChanged(string a)
        {
                PropertyChanged(this, new PropertyChangedEventArgs(a));
        }

    }
}
