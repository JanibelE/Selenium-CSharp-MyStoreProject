
using MyStoreProject.Configuration.Model;
using Newtonsoft.Json;

namespace MyStoreProject.Configuration
{
    public class Settings
    {
        public ConfigurationModel getSettings()
        {
            ConfigurationModel config = JsonConvert.DeserializeObject<ConfigurationModel>(File.ReadAllText(@"E:\Documentos\Proyectos\MyStoreProject\MyStoreProject\Configuration\Configuration.json"));

            return config;
        }
    }
}
