using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steamworks;
using Zerocool.API;
using Zerocool.API.Entities.v1;

namespace Zerocool.BasicClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SteamAPI.Init();
            HackmudApiClient apiClient = new HackmudApiClient();
            AuthenticationResult auth = apiClient.AuthenticateAsync(SteamAPIExtension.GetToken()).Result;
            Console.ReadLine();
        }
    }
}
