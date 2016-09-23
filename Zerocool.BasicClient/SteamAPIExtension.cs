using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steamworks;

namespace Zerocool.BasicClient
{
    public class SteamAPIExtension
    {
        public static string GetToken()
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bufferBytes = new byte[1024];
            uint outputLength = 0;
            SteamUser.GetAuthSessionTicket(bufferBytes, 1024, out outputLength);
            for(int i = 0; i < outputLength; i++)
            {
                stringBuilder.Append(bufferBytes[i].ToString("X2"));
            }
            return stringBuilder.ToString();
        }
    }
}
