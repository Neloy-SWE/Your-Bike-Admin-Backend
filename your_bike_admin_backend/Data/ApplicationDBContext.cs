using Microsoft.EntityFrameworkCore;
using your_bike_admin_backend.Models;

namespace your_bike_admin_backend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
