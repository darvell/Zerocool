using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Zerocool.Tests
{
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            string assemblyDirectory = Path.GetDirectoryName(typeof(TestSetup).Assembly.Location);
            Environment.CurrentDirectory = assemblyDirectory;
            Directory.SetCurrentDirectory(assemblyDirectory); // No risks!
        }
    }
}
