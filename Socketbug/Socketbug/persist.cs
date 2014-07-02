using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.IO;

namespace Socketbug
{
    public class persist
    {
        public static void Writepersist(string type, String filename, String filedata)
        {
            if (type == "txt")
            {
                IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
                StreamWriter writeme = new StreamWriter(new IsolatedStorageFileStream(filename, FileMode.Create, file));
                writeme.Write(filedata);
                writeme.Close();

            }
            else
            {
               
            }
        }
        public static string readerpersist(string filename)
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            StreamReader read = new StreamReader(new IsolatedStorageFileStream(filename,FileMode.Open , file));
            string ret = read.ReadToEnd();
            read.Close();
            return ret;
        }
    }
}
