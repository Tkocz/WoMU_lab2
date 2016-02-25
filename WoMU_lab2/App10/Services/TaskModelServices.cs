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
                +"&start=" + taskModel.BeginDateTime +"&deadline=" +taskModel.DeadlineDateTime);

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
        //   * /api/claimtask? taskID = A & userID = B
        //   *
        //   * Assignar en user till en task.
        //   *
        //   * Parametrar:
        //   *   
        //   *     A=id på en task
        //   *     B=id på den user som ska assignas till tasken
        //   *

        public async Task<bool> ClaimTaskModelAsync(TaskModel taskModel)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(WebServiceUrl + "claimtask?" + "taskId=" + taskModel.Id + "&userId=" + "3"/*taskModel.Users*/);

            return response.IsSuccessStatusCode;
        }
      
      //   * /api/releasetask? taskID = A & userID = B
      //   *
      //   * Tar bort en user från en task.
      //   *   
      //   *   Parametrar:
      //   *   
      //   *     A= id på en task
      //   * B = id på den user som ska tas bort från tasken
      //   *
        public async Task<bool> ReleaseTaskModelAsync(TaskModel taskModel)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(WebServiceUrl + "releasetask?" + "taskId=" + taskModel.Id + "&userId=" + "1"/*taskModel.Users*/);

            return response.IsSuccessStatusCode;
        }
    }
}
