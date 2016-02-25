using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using App10.Models;

namespace App10.Services
{
    public class UserModelServices
    {

        private const string WebServiceUrl = "http://localhost:16579/api/triforce/";

        public async Task<List<UserModel>> GetUserModelsAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + "Users");

            var UserModels = JsonConvert.DeserializeObject<List<UserModel>>(json);

            return UserModels;
        }

    }
}
