using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using Zerocool.API.Entities.v1;

namespace Zerocool.API
{
    public class HackmudApiClient
    {
        private const string BASE_API_URL = "https://www.hackmud.com";

        private Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            // Honestly I'm not sure creating a new client every request is a good idea even though every code example says to. Surely this is wasted overhead?
            RestClient client = new RestClient(BASE_API_URL)
            {
                UserAgent = "Zerocool / 0.0.1 / Hack The Gibson"
            };
            client.AddDefaultHeader("Authorization", $"Token token={ApiConstant.ApiKey}");

            TaskCompletionSource<T> taskCompletionSource = new TaskCompletionSource<T>();
            client.ExecuteAsync<T>(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    // TODO: Make sure this gets passed up right
                    throw response.ErrorException;
                }
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    ErrorResult error = JsonConvert.DeserializeObject<ErrorResult>(response.Content);
                    throw new ApiException(error.Message);
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
            request.AddJsonBody(new AuthenticationRequest(steamToken));

            return ExecuteAsync<AuthenticationResult>(request);
        }
        
        #endregion

    }
}
