using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Models
{
    public class Task
    {
        [Required]
        public int TaskId { get; set; }
        
        [Required]
        public string Title { get; set; }
        public bool Status { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
        
        // Task <-> User Relation many-to-many
        public int UserId { get; set; }
        public ICollection<User> User { get; set; }
        
        // Task <-> Priority Relations one-to-one
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }  
    }
}
