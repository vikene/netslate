using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Socketbug
{
     public class news : ObservableCollection<headlines> 
    {
         public news()
         { }
         public void localCheck()
         {
                      }
         public void analyser()
         {
             MainPage.anne();
         }
         

    }
}
