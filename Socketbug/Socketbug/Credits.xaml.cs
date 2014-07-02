using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
namespace Socketbug
{
    public partial class Credits : PhoneApplicationPage
    {
        public Credits()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask rev = new MarketplaceReviewTask();
            rev.Show();
        }
    }
}