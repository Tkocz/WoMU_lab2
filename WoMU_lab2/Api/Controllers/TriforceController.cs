using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Http;
using Api.Models;

namespace Api.Controllers
{
    /*
     * API-spec:
     * 
     * /api/triforce/tasks
     * 
     *   Ger en lista över alla tasks och deras users.
     *
     * /api/triforce/users
     * 
     *   Ger en lista över alla users.
     *   
     * /api/triforce/createtask?title=A&reqs=B&start=C&deadline=D
     * 
     *   Skapar en ny task.
     *   
     *   Parametrar:
     *   
     *     A=titel (ex. "Gör tomatsås")
     *     B=requirements (ex. "Köp tomater|Köp någon mer ingrediens")
     *     C=startdatum (ex. "2016-01-01")
     *     D=deadlinedatum (ex. "2016-01-01")
     *     
     * /api/deletetask?taskID=A
     * 
     *   Tar bort en task.
     *   
     *   Parametrar:
     *   
     *     A=id på den task som ska tas bort.
     * 
     * /api/claimtask?taskID=A&userID=B
     * 
     *   Assignar en user till en task.
     *   
     *   Parametrar:
     *   
     *     A=id på en task
     *     B=id på den user som ska assignas till tasken
     *  
     * /api/releasetask?taskID=A&userID=B
     * 
     *   Tar bort en user från en task.
     *   
     *   Parametrar:
     *   
     *     A=id på en task
     *     B=id på den user som ska tas bort från tasken
     *     
     */

    [RoutePrefix("api/Triforce/")]
public class TriforceController : ApiController {
    private static Database1Entities db = new Database1Entities();

    [HttpGet]
    public object Tasks() {
        var q = from task in db.Tasks
                select new Task() {
                    Id               = task.TaskId.ToString(),
                    Title            = task.Title,
                    Requirements     = task.Requirements,
                    BeginDateTime    = task.BeginDateTime,
                    DeadlineDateTime = task.DeadlineDateTime,
                    Users            = from user in task.Users
                                       select new User() {
                                           Id        = user.UserId.ToString(),
                                           FirstName = user.FirstName,
                                           LastName  = user.LastName
                                       }
                };

        return Json(q.ToArray());
    }

    [HttpGet]
    public object Users() {
        var q = from user in db.Users
                select new User() {
                    Id        = user.UserId.ToString(),
                    FirstName = user.FirstName,
                    LastName  = user.LastName
                };

        return Json(q.ToArray());
    }
    [HttpGet]
    public object CreateTask(string title, string reqs, DateTime start,
                             DateTime deadline)
    {

            var task = new Tasks() {
            Title            = title,
            Requirements     = reqs,
            BeginDateTime    = start,
            DeadlineDateTime = deadline,
        };

        db.Tasks.Add(task);
        db.SaveChanges();

        return Json(task);
    }

    [HttpGet]
    public object DeleteTask(int taskID)
    {
        var task = (from t in db.Tasks where t.TaskId == taskID select t).Single();

        db.Tasks.Remove(task);
        db.SaveChanges();

        return Json(task);
    }

    [HttpGet]
    public object ClaimTask(int taskID, int userID)
    {
        var task = (from t in db.Tasks where t.TaskId == taskID select t).Single();
        var user = (from u in db.Users where u.UserId == userID select u).Single();

        task.Users.Add(user);
        db.SaveChanges();

        return Json("ok");
    }

    [HttpGet]
    public object ReleaseTask(int taskID, int userID)
    {
        var task = (from t in db.Tasks where t.TaskId == taskID select t).Single();
        var user = (from u in db.Users where u.UserId == userID select u).Single();

        task.Users.Remove(user);
        db.SaveChanges();

        return Json("ok");
    }
    [HttpGet]
    public object EditTask(int taskID, string title, string reqs, DateTime start,
                        DateTime deadline)
    {
        var task = (from t in db.Tasks where t.TaskId == taskID select t).Single();

        task.Title = title;
        task.Requirements = reqs;
        task.BeginDateTime = start;
        task.DeadlineDateTime = deadline;

        db.SaveChanges();

        return Json("ok");
    }
    }

}
