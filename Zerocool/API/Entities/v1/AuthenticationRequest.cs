using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zerocool.API.Entities.v1
{
    public class AuthenticationRequest
    {
        [JsonProperty(PropertyName = "steam_session_key")]
        public string SteamSessionKey { get; set; }

        public AuthenticationRequest(string steamSessionKey)
        {
            SteamSessionKey = steamSessionKey;
        }
    }
}
