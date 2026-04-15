using TaskManager;
using TaskManager.Repositories;

var context = new TaskManagerContext();
var taskRepo = new TaskRepository(context);
var userRepo = new UserRepository(context);

bool running = true;

while (running)
{
    Console.WriteLine("\n=== Task Manager ===");
    Console.WriteLine("1. View all tasks");
    Console.WriteLine("2. Add a task");
    Console.WriteLine("3. Update a task");
    Console.WriteLine("4. Delete a task");
    Console.WriteLine("5. View all users");
    Console.WriteLine("6. Add a user");
    Console.WriteLine("7. Update a user");
    Console.WriteLine("8. Delete a user");
    Console.WriteLine("9. Exit");
    Console.Write("Choice: ");

    switch (Console.ReadLine())
    {
        case "1":
            var tasks = taskRepo.GetAllTasks();

            if(tasks == null)
            {
                Console.WriteLine("No Task Available");
            }

            foreach (var t in tasks)
                Console.WriteLine($"[{t.TaskId}] {t.Title} - Priority: {t.Priority.Title}");
            break;


        case "2":
            Console.Write("Task title: ");
            string title = Console.ReadLine();

            Console.Write("Priority (1=High, 2=Medium, 3=Low): ");
            int priorityId = int.Parse(Console.ReadLine());

            taskRepo.AddTask(new TaskManager.Models.Task { Title = title, PriorityId = priorityId });
            Console.WriteLine("Task added!");
            break;


        case "3":
            Console.Write("Task ID to update: ");
            int updateId = int.Parse(Console.ReadLine());

            var task = taskRepo.GetTaskById(updateId);
            if (task != null)
            {
                Console.Write("New title: ");
                task.Title = Console.ReadLine();
                taskRepo.UpdateTask(task);
                Console.WriteLine("Task updated!");
            }
            break;


        case "4":
            Console.Write("Task ID to delete: ");
            int deleteId = int.Parse(Console.ReadLine());
            taskRepo.DeleteTask(deleteId);
            Console.WriteLine("Task deleted!");
            break;


        case "5":
            // View all users
            var users = userRepo.GetAllUsers();
            foreach (var u in users)
                Console.WriteLine($"[{u.UserId}] {u.Name} — Tasks: {u.Tasks?.Count ?? 0}");
            break;


        case "6":
            // Add a user
            Console.Write("Name: ");
            string name = Console.ReadLine();

            userRepo.AddUser(new TaskManager.Models.User { Name = name});
            break;


        case "7":
            // Update a user
            Console.Write("User ID to update: ");
            int uid = int.Parse(Console.ReadLine());

            var foundUser = userRepo.GetUserById(uid);
            if (foundUser != null)
            {
                Console.Write("New username: ");
                foundUser.Name = Console.ReadLine();

                userRepo.UpdateUser(foundUser);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
            break;

        case "8":
            // Delete a user
            Console.Write("User ID to delete: ");
            int deleteUid = int.Parse(Console.ReadLine());

            userRepo.DeleteUser(deleteUid);
            break;

        case "9":
            running = false;
            break;
    }
}
