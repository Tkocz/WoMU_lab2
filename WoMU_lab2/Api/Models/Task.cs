using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime DeadlineDateTime { get; set; }
        public IEnumerable<User> Users { get; set; }

    }

}
