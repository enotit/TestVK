using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace TestVK.Entities
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonProperty("user_group")]
        public int UserGroup { get; set; }
        [JsonProperty("user_state")]
        public int UserState { get; set; }

        public bool SetPassword(string userPassword)
        {
            string hashedPassword = GetHashedPassword(userPassword);
            if (hashedPassword == string.Empty) return false;
            Password = hashedPassword;

            return true;
        }

        private string GetHashedPassword(string userPassword)
        {
            if (userPassword == null) return string.Empty;

            userPassword += CreatedDate.ToString();
            string hash;
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] passwordByByte = Encoding.UTF8.GetBytes(userPassword);
                string? hashByte = shaM.ComputeHash(passwordByByte).ToString();
                if (hashByte == null) return string.Empty;
                hash = hashByte;
            }
            return hash;
        }

        public bool IsTruthPassword(string userPassword)
        => GetHashedPassword(userPassword) == Password;
    }
}
