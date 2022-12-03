using System;
using Alliance_API.Models;
using Microsoft.EntityFrameworkCore;
using migo_be.Models;

namespace Alliance_API.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<Project>  Projects => Set<Project>();

        public DbSet<HRUser> HRUsers => Set<HRUser>();

        public DbSet<EmployeeTimeLogs> EmployeeTimeLogs => Set<EmployeeTimeLogs>();

        public DbSet<Benefits> Benefits => Set<Benefits>();

        public DbSet<Assessment> Assessments => Set<Assessment>();
        public DbSet<Innovation> Innovations => Set<Innovation>();
        public DbSet<Agility> Agilities => Set<Agility>();
        public DbSet<Efficiency> Efficiencies => Set<Efficiency>();
        public DbSet<Integrity> Integrities => Set<Integrity>();

        public DbSet<FunctionalComponents> FunctionalComponents => Set<FunctionalComponents>();
        public DbSet<Performance> Performances => Set<Performance>();
    }
}

