using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoreProject.Configuration.Model
{
    public class ConfigurationModel
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Browser { get; set; }
        public string implicitWait { get; set; }
        public string pageLoadTimeOut { get; set; }


    }
}
