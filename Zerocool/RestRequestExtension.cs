using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Zerocool.Serialization;

namespace Zerocool
{
    public static class RestRequestExtension
    {
        public static void SetJsonContent(this RestRequest request, object obj)
        {
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;
            request.AddJsonBody(obj);
        }
    }
}
