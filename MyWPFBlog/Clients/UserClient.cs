using Microsoft.Extensions.Configuration;
using MyModels.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace MyWPFBlog.Clients
{
    public interface IUserClient
    {
        Task<ApiResult> Create(string name, string password, string username);

        Task<ApiResult> Edit(string name);
        Task<ApiResult> GetWriters();
    }
    public class UserClient : IUserClient,IDisposable
    {
        private RestClient _client;
        private string createWriterUrl;
        private string getWritersUrl;
        private string? editWriterUrl;

        public UserClient(IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("ApiUrl");
            createWriterUrl = configuration.GetValue<string>("CreateWriter");
            getWritersUrl = configuration.GetValue<string>("GetWriters");
            editWriterUrl = configuration.GetValue<string>("EditWriter");
            var options = new RestClientOptions(url);
            _client = new RestClient(options);
        }
        public async Task<ApiResult> Create(string name,string password,string username)
        {
            var request = new RestRequest(createWriterUrl, Method.Post)
                .AddParameter("name", name)
                .AddParameter("userName", username)
                .AddParameter("pwd", password);
            var response = await _client.PostAsync<ApiResult>(request);
            return response;
        }

      
        public async Task<ApiResult> Edit(string name)
        {
            var request = new RestRequest(editWriterUrl, Method.Put)
               .AddParameter("name", name);
            var response = await _client.PutAsync<ApiResult>(request);
            return response;
        }

        public async Task<ApiResult> GetWriters()
        {
            var request = new RestRequest(getWritersUrl);
            var response =await _client.GetAsync<ApiResult>(request);
            return response;
        }
        public void Dispose()
        {
            _client?.Dispose();
        }

    }
}
