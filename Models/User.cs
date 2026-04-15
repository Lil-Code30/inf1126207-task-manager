using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set;  }
        
        // User <-> Task Relation : one-to-many
        public ICollection<Task> Tasks { get; set; }

        public User()
        {
            Tasks = new List<Task>();
        }

    }
}
