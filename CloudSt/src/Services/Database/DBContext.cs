using Microsoft.EntityFrameworkCore; 
using CloudST.Models;

namespace CloudST.Database 
{ 
    public class DataBaseContext : DbContext 
    { 
        public DbSet<User> Users {get; set; }  
        public DbSet<Files> Files_ {get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base (options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<User>().HasKey(u => u.ID); 
            modelBuilder.Entity<Files>().HasKey(f => f.ID);
        }
    }
}