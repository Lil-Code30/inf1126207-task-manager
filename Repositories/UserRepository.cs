using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Repositories
{
    public class UserRepository
    {
        private readonly TaskManagerContext _context;

        public UserRepository(TaskManagerContext context)
        {
            _context = context;
        }

        // CREATE
        public void AddUser(Models.User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            Console.WriteLine($"User '{user.Name}' added successfully!");
        }

        // READ ALL
        public List<Models.User> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Tasks)
                .ToList();
        }

        // READ ONE
        public Models.User GetUserById(int id)
        {
            return _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefault(u => u.UserId == id);
        }

        // READ BY Name
        public Models.User GetUserByUsername(string name)
        {
            return _context.Users
                .FirstOrDefault(u => u.Name == name);
        }

        // UPDATE
        public void UpdateUser(Models.User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            Console.WriteLine($"User '{user.Name}' updated successfully!");
        }

        // DELETE
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                Console.WriteLine($"User '{user.Name}' deleted successfully!");
            }
            else
            {
                Console.WriteLine($"User with ID {id} not found.");
            }
        }
    }
}
