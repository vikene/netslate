using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;

namespace Socketbug
{
    public class setting
    {
        public setting()
        {
        }
        public void Init_setting()
        {
            IsolatedStorageSettings mysetting = IsolatedStorageSettings.ApplicationSettings;
            if(mysetting.Contains("polls"))
            {
            }
            else{
            mysetting["polls"] = "20";
            mysetting["author"] = "vigneash";
            mysetting["background"] = "true";
            mysetting["cachedata"] = true;
            mysetting.Save();
            }
        }

        public bool clear(string key)
        {
            if (key == null)
            {
                return false;
            }

            IsolatedStorageSettings mysetting = IsolatedStorageSettings.ApplicationSettings;
            if (mysetting.Contains(key))
            {
                mysetting.Remove(key);
            }
            if (!mysetting.Contains(key))
            {
                return true;
            }
            return true;
        }
        public bool save(string key, string value)
        {
           
            
                IsolatedStorageSettings myset = IsolatedStorageSettings.ApplicationSettings;
                
                    
                    
                        myset[key] = value;
                        myset.Save();
                   
                
            
           
            return true;
        }
        public T persist_load<T>(string key)
        {
            IsolatedStorageSettings myset = IsolatedStorageSettings.ApplicationSettings;

            return (T)myset[key];

        }
       
    }
}
