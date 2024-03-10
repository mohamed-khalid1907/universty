using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Professor>().HasData(
                new Models.Professor { ProfessorId = 1, ProfessorName = "mohamed", DepID =1 },
                new Models.Professor
                {
                    ProfessorId = 2,
                    ProfessorName = "khalid",
                    DepID = 2
                }
                );
                modelBuilder.Entity<Models.Department>().HasData(
                new Models.Department {DepartmebtID=1},new Models.Department {DepartmebtID=2}
                
                )
                 ;
        }
    }
}
