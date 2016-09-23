using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zerocool.API.Entities.v1
{
    public class CheckUsernameRequest
    {
        [JsonProperty(PropertyName = "version")]
        public Dictionary<string, object> Version = ApiConstant.Version;

        [JsonProperty(PropertyName="username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "account_token")]
        public string AccountToken { get; set; }

        [JsonProperty(PropertyName = "confirmed")]
        public bool Confirmed { get; set; }

        public CheckUsernameRequest(string accountToken, string username, bool confirm = false)
        {
            AccountToken = accountToken;
            Username = username;
            Confirmed = confirm;
        }

    }
}
