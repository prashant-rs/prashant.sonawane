using First_Web_Application.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace First_Web_Application.Data
{
    public class ApplicationDBContext:DbContext//APD it is brindge betw.our apllication and SQL server 
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
