using bulletin.Models;
using Microsoft.EntityFrameworkCore;

namespace bulletin.Entity
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<LoginLog> LoginLogs { get; set; }
    }
}
