using Microsoft.EntityFrameworkCore;
public class HrContext : DbContext
{
    public HrContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departmnets { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<SpLoginDto> SpLoginDto { get; set; }


    public async Task<IEnumerable<SpLoginDto>> GetLoginProc(int employeeid)
    {
        return await this.Set<SpLoginDto>()
        .FromSqlInterpolated($"proc_LoginGet {employeeid}").ToListAsync(); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(e => e.Id).HasName("PK_Employee");

        modelBuilder.Entity<Department>().HasKey(d => d.DepartmentNumber).HasName("PK_Department");

        modelBuilder.Entity<Employee>().HasOne(e => e.Department)
                                    .WithMany(d => d.Employees)
                                    .HasForeignKey(e => e.DepartmentId)
                                    .HasConstraintName("FK_Employee_Departmnet")
                                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>().HasKey(u => u.UserId).HasName("PKK_User");

        modelBuilder.Entity<User>().HasOne(u => u.Employee)
                                    .WithOne(e => e.User)
                                    .HasForeignKey<User>(u => u.UserId)
                                    .HasConstraintName("FK_Employee_User")
                                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentNumber = 101, Name = "HR" },
            new Department { DepartmentNumber = 102, Name = "Operations" }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Ramu", Phone = "9876543210", DepartmentId = 101 },
            new Employee { Id = 2, Name = "Somu", Phone = "4321098765", DepartmentId = 101 }
        );

    }
}