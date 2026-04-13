using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }  
    }
}
