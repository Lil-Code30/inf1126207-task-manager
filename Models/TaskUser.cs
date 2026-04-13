using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models;

public class TaskUser
{
    [Key]
    public int TaskUserId { get; set; } // primary key
    
    [ForeignKey("TaskId")]
    public Task Task { get; set; } // Foreign key
    
    [ForeignKey("UserId")]
    public User User { get; set; } // Foreign key
} 