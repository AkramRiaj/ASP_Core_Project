using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP_Core_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ASP_Core_Project.Data
{
    


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }


        public DbSet<ASP_Core_Project.Models.Notice> Notice { get; set; }

        public DbSet<ASP_Core_Project.Models.Employee> Employee { get; set; }

        public DbSet<ASP_Core_Project.Models.Certificate> Certificate { get; set; }

        public DbSet<ASP_Core_Project.Models.Company> Company { get; set; }

        public DbSet<ASP_Core_Project.Models.Department> Department { get; set; }

        public DbSet<ASP_Core_Project.Models.EmploymentHistory> EmploymentHistory { get; set; }

        public DbSet<ASP_Core_Project.Models.Institute> Institute { get; set; }

        public DbSet<ASP_Core_Project.Models.Job> Job { get; set; }

        public DbSet<ASP_Core_Project.Models.MenuHelperModel> MenuHelperModel { get; set; }


        public DbSet<ASP_Core_Project.Models.MenuModel> MenuModel { get; set; }


        public DbSet<ASP_Core_Project.Models.MenuModelManage> MenuModelManage { get; set; }

        public DbSet<ASP_Core_Project.Models.ApplicationRole> ApplicationRole { get; set; }


        public DbSet<ASP_Core_Project.Models.ApplicationUserRole> ApplicationUserRole { get; set; }
    }



    public class SelectedDetailsModel
    {
        public IEnumerable<Job> Job { get; set; }
        public IEnumerable<Company> Company { get; set; }
        public IEnumerable<Department> Department { get; set; }
        public IEnumerable<Employee> Employee { get; set; }
        
        public IEnumerable<EmploymentHistory> EmploymentHistory { get; set; }

    }
}
