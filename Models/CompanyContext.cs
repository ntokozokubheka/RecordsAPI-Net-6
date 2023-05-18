using Microsoft.EntityFrameworkCore;
using RecordsAPI.Models;

namespace RecordsAPI.Models
{
    public class CompanyContext :DbContext
    {

        public CompanyContext(DbContextOptions options)
            : base(options)
        {


        }

        public DbSet<Employee>Employees { get; set; } 

    }
}
