using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set;  }
        
        // User <-> Task Relation : one-to-many
        public ICollection<Task> Tasks { get; set; }

        public User()
        {
            Tasks = new List<Task>();
        }

    }
}
