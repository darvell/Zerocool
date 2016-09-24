using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using Zerocool.API.Entities;
using Zerocool.API.Entities.v1;
using Zerocool.Serialization;

namespace Zerocool.API
{
    public class HackmudApiClient
    {
        private const string BASE_API_URL = "https://www.hackmud.com";
        private const string API_USER_AGENT = "Zerocool / 0.0.1 / Hack The Gibson";

        private Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            // Honestly I'm not sure creating a new client every request is a good idea even though every code example says to. Surely this is wasted overhead?
            RestClient client = new RestClient(BASE_API_URL)
            {
                UserAgent = API_USER_AGENT
            };
            client.AddDefaultHeader("Authorization", $"Token token={ApiConstant.ApiKey}");
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            client.AddHandler("*+json", NewtonsoftJsonSerializer.Default);

            TaskCompletionSource<T> taskCompletionSource = new TaskCompletionSource<T>();
            client.ExecuteAsync<T>(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    taskCompletionSource.SetException(response.ErrorException);
                    return;
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    ErrorResult error = JsonConvert.DeserializeObject<ErrorResult>(response.Content);
                    taskCompletionSource.SetException(new ApiException(error.Message));
                    return;
                }
                taskCompletionSource.SetResult(response.Data);
            });

            return taskCompletionSource.Task;
        }

        #region Wrapped Methods
        public Task<AuthenticationResult> AuthenticateAsync(string steamToken)
        {
            RestRequest request = new RestRequest("accounts/sign_in_steam_session.json", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.SetJsonContent(new AuthenticationRequest(steamToken));

            return ExecuteAsync<AuthenticationResult>(request);
        }

        #endregion

    }
}
