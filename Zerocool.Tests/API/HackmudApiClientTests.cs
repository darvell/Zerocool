using Zerocool.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Zerocool.API.Entities.v1;
using Steamworks;
using Zerocool.Tests;

namespace Zerocool.API.Tests
{
    [TestFixture]
    public class HackmudApiClientTests
    {
        [Test]
        public async Task AuthenticateAsyncTest()
        {
            HackmudApiClient apiClient = new HackmudApiClient();
            AuthenticationResult result = null;
            Console.WriteLine(SteamAPI.Init());
            result = await apiClient.AuthenticateAsync(SteamAPIExtension.GetToken());
            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.AuthenticationToken);
            Assert.IsTrue(result.AuthenticationToken.Length > 0);
            Assert.Pass();
        }

        [Test]
        public async Task AuthenticateAsyncFailTest()
        {
            HackmudApiClient apiClient = new HackmudApiClient();
            AuthenticationResult result = null;
            result = await apiClient.AuthenticateAsync("thisWillNotWork");
            Assert.IsNotNull(result.Error);
        }
    }
}