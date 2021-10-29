using GestaoUnica_backend.Interfaces;
using GestaoUnica_backend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GestaoUnica_backend.Services
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        private readonly IConfiguration _config;

        private string _baseUrl = string.Empty;
        private string _endpointLogin = string.Empty;

        public ActiveDirectoryService(IConfiguration config)
        {
            _config = config;
            _baseUrl = _config.GetSection("ActiveDirectory:API_Base_AD").Value.ToString();
        }
        
        public async Task<bool> IsADAuthenticated(User user)
        {
            _endpointLogin = _config.GetSection("ActiveDirectory:LoginEndpoint").Value.ToString();
            
            var credentials = new
            {
                user.Username,
                user.Password
            };
            var uri = string.Format("{0}{1}", this._baseUrl, this._endpointLogin);
            
            var authenticated = false;

            var jsonString = JsonConvert.SerializeObject(credentials);

            using(HttpClient client = new HttpClient())
            {
                var result = await client.PostAsync(uri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
                
                if (result.StatusCode == HttpStatusCode.OK)
                    authenticated = true;
            }
                        
            return authenticated;
        }
    }
}
