using System.IO;
using Newtonsoft.Json;
using Module3HW2.Configurations;

namespace Module3HW2.Services
{
    public class ConfigurationService
    {
        private const string ConfigPath = "config.json";
        private Config _config;

        public ConfigurationService()
        {
            Init();
        }

        public Config Config => _config;

        private void Init()
        {
            var configFile = File.ReadAllText(ConfigPath);
            _config = JsonConvert.DeserializeObject<Config>(configFile);
        }
    }
}
