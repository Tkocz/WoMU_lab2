namespace Api.Controllers {

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

// These POD-classes are needed because C# sucks Satan's ass.
public class Task {
    public string            Id               { get; set; }
    public string            Title            { get; set; }
    public string            Requirements     { get; set; }
    public DateTime          BeginDateTime    { get; set; }
    public DateTime          DeadlineDateTime { get; set; }
    public IEnumerable<User> Users            { get; set; }

}

public class User {
    public string Id        { get; set; }
    public string FirstName { get; set; }
    public string LastName  { get; set; }
}

[RoutePrefix("api/Triforce")]
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
    public void Create(string title, string requirements, DateTime start,
                       DateTime deadline, int userID)
    {
        var task = new Tasks() {
            Title            = title,
            Requirements     = requirements,
            BeginDateTime    = start,
            DeadlineDateTime = deadline,
        };

        task.Users.Add((from user in db.Users where user.UserId == userID select user).Single());
        db.Tasks.Attach(task);
        db.SaveChanges();
    }
}

}
