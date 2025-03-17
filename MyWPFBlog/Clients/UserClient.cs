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
        Task<bool> Create(string name, string password, string username);

        Task<WriterDTO> Edit(string name);
        Task<IEnumerable<WriterDTO>> GetWriters();
    }
    public class UserClient : IUserClient, IDisposable
    {
        private RestClient _client;
        private string createWriterUrl;
        private string getWritersUrl;
        private string editWriterUrl;

        public UserClient(IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("ApiUrl");
            createWriterUrl = configuration.GetValue<string>("CreateWriter");
            getWritersUrl = configuration.GetValue<string>("GetWriters");
            editWriterUrl = configuration.GetValue<string>("EditWriter");
            var options = new RestClientOptions(url);
            _client = new RestClient(options);
        }
        public async Task<bool> Create(string name, string password, string username)
        {
            var request = new RestRequest(createWriterUrl, Method.Post)
                .AddQueryParameter("name", name)
                .AddQueryParameter("userName", username)
                .AddQueryParameter("pwd", password);
            var response = await _client.PostAsync<ApiResult>(request);
            return response.Code == 200;
        }


        public async Task<WriterDTO> Edit(string name)
        {
            var request = new RestRequest(editWriterUrl, Method.Put)
               .AddParameter("name", name);
            var response = await _client.PutAsync<ApiResult>(request);
            if (response.Code==200)
            {
                if (response.Data is WriterDTO dto)
                {
                    return dto;
                }
            }
            return null;
        }

        public async Task<IEnumerable<WriterDTO>> GetWriters()
        {
            var request = new RestRequest(getWritersUrl);
            var response = await _client.GetAsync<ApiResult>(request);
            if (response.Code==200)
            {
                if (response.Data is List<WriterDTO> dtoList)
                {
                    return dtoList;
                }
            }
            return null;
        }
        public void Dispose()
        {
            _client?.Dispose();
        }

    }
}
