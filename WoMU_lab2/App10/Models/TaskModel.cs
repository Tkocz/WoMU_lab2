using System;
using System.Collections.Generic;

namespace App10.Models
{
    public class TaskModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime DeadlineDateTime { get; set; }
        public IEnumerable<User> Users { get; set; }

    }
}

public class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}