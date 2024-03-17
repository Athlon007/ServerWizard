using Newtonsoft.Json;
using ServerWizard.Models;

namespace ServerWizard.Services
{
    internal class ConfigService
    {
        public const string SaveFile = "config.json";

        public void Save(Config config)
        {
            string output = JsonConvert.SerializeObject(config);
            StreamWriter outputWriter = new StreamWriter(SaveFile);
            outputWriter.Write(output);
            outputWriter.Close();
        }

        public Config Load()
        {
            if (!File.Exists(SaveFile))
            {
                var output = new Config();
                Save(output);
                return output;
            }

            try
            {
                StreamReader sr = new StreamReader(SaveFile);
                string content = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<Config>(content) ?? new Config();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Config();
            }
        }
    }
}
