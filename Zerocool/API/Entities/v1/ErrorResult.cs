using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zerocool.API.Entities.v1
{
    public class ErrorResult
    {
        [JsonProperty(PropertyName = "msg")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
    }
}
