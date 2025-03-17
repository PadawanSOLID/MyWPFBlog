using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Utilities;

namespace MyWPFBlog.Clients
{
    public interface IAuthorizeClient
    {
        Task<string> Login(string name, string password);
    }
    public class AuthorizeClient : IAuthorizeClient, IDisposable
    {
        private RestClient _client;
        private string loginUrl;
        public AuthorizeClient(IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("JwtUrl");
            loginUrl = configuration.GetValue<string>("Login");
            var options = new RestClientOptions(url);
            _client = new RestClient(options);
        }
        public void Dispose()
        {
            _client?.Dispose();
        }

        public async Task<string> Login(string name, string password)
        {
            var request = new RestRequest(loginUrl, Method.Post)
                .AddQueryParameter("username", name)
                .AddQueryParameter("pwd", password);
            var result =await _client.PostAsync<ApiResult>(request);
            if (result.Code==200)
            {
                if (result.Data is JsonElement token)
                {
                    return token.GetString();
                }
            }
            return null;
        }
    }
}
