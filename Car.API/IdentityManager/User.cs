using System.Text.Json.Serialization;

namespace Car.API.IdentityManager
{
    public class User
    {
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
