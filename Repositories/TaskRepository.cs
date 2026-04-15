using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Repositories
{
    public class TaskRepository
    {
        private readonly TaskManagerContext _context;

        public TaskRepository(TaskManagerContext context)
        {
            _context = context; 
        }

        public void AddTask(Models.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public List<Models.Task> GetAllTasks()
        {
            // Include() loads related Priority and User data
            return _context.Tasks.Include(t => t.Priority).Include(t => t.User).ToList();
        }  

        public Models.Task GetTaskById(int id)
        {
            return _context.Tasks.Include(t => t.Priority).FirstOrDefault(t => t.TaskId == id);
        }

        public void UpdateTask(Models.Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {

            var task = _context.Tasks.Find(id);
            if(task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
