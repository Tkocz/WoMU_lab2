using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using App10.Models;

namespace App10.Services
{
    public class TaskModelServices
    {

        private const string WebServiceUrl = "http://localhost:16579/api/triforce/";

        public async Task<List<TaskModel>> GetTaskModelsAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + "Tasks");

            var taskModels = JsonConvert.DeserializeObject<List<TaskModel>>(json);

            return taskModels;
        }

        public async Task<bool> AddTaskModelAsync(TaskModel taskModel)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(taskModel);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl + "createtask" , httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTaskModelAsync(TaskModel taskModel)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + "deletetask" + taskModel.Id);

            return response.IsSuccessStatusCode;
        }
    }
}
