using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zerocool.API.Entities.v1
{
    public static class ApiConstant
    {
        public static Dictionary<string, object> Version = new Dictionary<string, object> { { "major", 1 }, { "minor", 3 }, { "build", 28 } }; // TODO: Write version obj converter
        public static string ApiKey = "temporary_key";
    }
}
