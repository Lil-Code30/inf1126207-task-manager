# TaskManager — Console App
 
A simple C# console application to manage tasks, users, and priorities using Entity Framework Core and SQL Server.
 
---

## Tech Stack
 
- **Language**: C# (.NET)
- **ORM**: Entity Framework Core
- **Database**: Microsoft SQL Server (SQLEXPRESS)
 
---

## Project Structure
 
```
TaskManager/
├── TaskManagerContext.cs     # DbContext — DB connection & table definitions
├── Models/
│   ├── Task.cs                   # Task model
│   ├── User.cs                   # User model
│   └── Priority.cs               # Priority model
├── Repositories/
│   ├── TaskRepository.cs         # CRUD operations for Tasks
│   ├── UserRepository.cs         # CRUD operations for Users
│   └── PriorityRepository.cs     # CRUD operations for Priorities // not implemented
└── Program.cs                    # Main menu & user interaction
```
 
---

## Getting Started
 
### 1. Prerequisites
 
- [.NET SDK](https://dotnet.microsoft.com/download)
- Microsoft SQL Server
- Visual Studio or VS Code
 
### 2. Install Dependencies
 
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```
 
### 3. Install EF Core CLI Tools
 
```bash
dotnet tool install --global dotnet-ef
```
 
### 4. Configure the Connection String
 
In `TaskManagerContext.cs`, update the connection string to match your SQL Server instance:
 
```csharp
string connection_string = "Data Source=YOUR_SERVER\\SQLEXPRESS;Initial Catalog=TaskManagerDB;Integrated Security=True;Encrypt=False";
```
 
### 5. Run Migrations
 
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
 
This will create the database and seed the default priorities (High, Medium, Low).
 
### 6. Run the App
 
```bash
dotnet run
```
 
---
 
## Features
 
| Feature         | Description                              |
|----------------|------------------------------------------|
| View Tasks      | List all tasks with priority and user    |
| Add Task        | Create a new task                        |
| Update Task     | Edit an existing task                    |
| Delete Task     | Remove a task by ID                      |
| View Users      | List all users with their tasks          |
| Add User        | Register a new user                      |
| Update User     | Edit an existing user                    |
| Delete User     | Remove a user by ID                      |
 
---
 
## Default Seed Data
 
The following priorities are automatically inserted on first migration:
 
| ID | Title  |
|----|--------|
| 1  | High   |
| 2  | Medium |
| 3  | Low    |
 
---