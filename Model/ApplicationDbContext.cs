using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }
        public ApplicationDbContext()
        {
            // this.Database.SetConnectionString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                optionsBuilder = new DbContextOptionsBuilder();
            }
            if (!optionsBuilder.IsConfigured)
            {

                var cs = "Server=localhost;Database=ExamCCI_2023;port=3307;user=ExamCCI_2023;password=ExamCCI_2023";
                optionsBuilder.UseMySql(cs, ServerVersion.AutoDetect(cs));
                base.OnConfiguring(optionsBuilder);
            }
        }
    }


}