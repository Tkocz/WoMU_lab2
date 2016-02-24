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

         //* /api/triforce/createtask? title = A & reqs = B & start = C & deadline = D
         //*
         //* Skapar en ny task.
         //*
         //* Parametrar:
         //*   
         //*     A=titel(ex. "Gör tomatsås")
         //*     B=requirements(ex. "Köp tomater|Köp någon mer ingrediens")
         //*     C=startdatum(ex. "2016-01-01")
         //*     D=deadlinedatum(ex. "2016-01-01")
        public async Task<bool> AddTaskModelAsync(TaskModel taskModel)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(taskModel);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.GetAsync(WebServiceUrl + "createtask?"
                +"title=" + taskModel.Title + "&reqs=" +taskModel.Requirements
                +"&start=2015-11-12" /*+ taskModel.BeginDateTime*/ +"&deadline=2016-03-23"/* +taskModel.DeadlineDateTime*/);

            return result.IsSuccessStatusCode;
        }
        // * /api/deletetask? taskID = A
        // *
        // * Tar bort en task.
        // *
        // * Parametrar:
        // *   
        // *     A=id på den task som ska tas bort.
        public async Task<bool> DeleteTaskModelAsync(TaskModel taskModel)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(WebServiceUrl + "deletetask?" +"taskId=" + taskModel.Id);

            return response.IsSuccessStatusCode;
        }
    }
}
