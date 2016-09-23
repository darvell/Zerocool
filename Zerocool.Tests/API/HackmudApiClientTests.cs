using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zerocool.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zerocool.API.Entities.v1;

namespace Zerocool.API.Tests
{
    [TestClass()]
    public class HackmudApiClientTests
    {
        [TestMethod]
        public void AuthenticateAsyncTest()
        {
            HackmudApiClient apiClient = new HackmudApiClient();
            AuthenticationResult result = apiClient.AuthenticateAsync(File.ReadAllText("token.txt")).Result;
            Assert.IsNotNull(result.AuthenticationToken);
            Assert.IsTrue(result.AuthenticationToken.Length > 0);
        }

        [TestMethod]
        public void AuthenticateAsyncFailTest()
        {
            HackmudApiClient apiClient = new HackmudApiClient();
            try
            {
                AuthenticationResult result = apiClient.AuthenticateAsync("thisIsInvalid").Result;
                Assert.Fail("No exception thrown on invalid login.");
            }
            catch (ApiException)
            {

            }
            catch (Exception)
            {
                Assert.Fail("Incorrect exception.");
            }
        }
    }
}