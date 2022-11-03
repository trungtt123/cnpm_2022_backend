
using Newtonsoft.Json;

namespace CNPM.Core.Models
{
    public class UserDto1004
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
