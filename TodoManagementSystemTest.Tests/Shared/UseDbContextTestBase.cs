using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoManagementSystem.Infrastructure.DataModels;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TodoManagementSystemTest.Tests.Shared
{
    public abstract class UseDbContextTestBase
    {
        protected AppDbContext TestDbContext;
        protected UseDbContextTestBase()
        {
            TestDbContext = new AppDbContext(
                options: new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("todo_management_system_test_db")
                .Options);

            TestDbContext.Database.EnsureCreated();
        }

        [SetUp]
        public virtual async Task SetupAsync()
        {
            TestDbContext.Users.RemoveRange(TestDbContext.Users);
            TestDbContext.UserProfiles.RemoveRange(TestDbContext.UserProfiles);

            TestDbContext.Todos.RemoveRange(TestDbContext.Todos);

            await TestDbContext.SaveChangesAsync();
        }
    }
}
