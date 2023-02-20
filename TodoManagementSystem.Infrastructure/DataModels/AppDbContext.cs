using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoManagementSystem.Infrastructure.DataModels.Todos;
using TodoManagementSystem.Infrastructure.DataModels.Users;

namespace TodoManagementSystem.Infrastructure.DataModels
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<UserProfileDataModel> UserProfiles { get; set; }
        public DbSet<TodoDataModel> Todos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
