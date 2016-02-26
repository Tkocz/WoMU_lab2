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
        public IEnumerable<UserModel> Users { get; set; }
    }
}

