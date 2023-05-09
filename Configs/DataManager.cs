using Newtonsoft.Json;
using System.Diagnostics;

namespace TestVK.Configs
{
    public static class DataManager
    {
        private const string ROOT_PATH = "Configs/json/";
        private const string DB_FILE = "db.json";
        private const string SALT_FILE = "salt.json";
        public static string? GetSalt()
        {
            string? answer;
            using (StreamReader r = new StreamReader(ROOT_PATH + SALT_FILE))
            {
                string json = r.ReadToEnd();
                answer = JsonConvert.DeserializeObject<string>(json);
            }
            return answer;
        }

        public static DbConfig GetDbConfig()
        {
            DbConfig answer;
            using (StreamReader r = new StreamReader(ROOT_PATH + DB_FILE))
            {
                string json = r.ReadToEnd();
                answer = JsonConvert.DeserializeObject<DbConfig>(json);
            }
            return answer;
        }
        public static string GetDbConfigString()
        {
            using (StreamReader r = new StreamReader(ROOT_PATH + DB_FILE))
            { 
                return r.ReadToEnd();
            }
        }
    }
    public class DbConfig
    {
        public string Host;
        public uint Port;
        public string Database;
        public string Username;
        public string password;
    }
}
