using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyUni.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyUni.Web.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<MyIdentityUser, MyIdentityRole, Guid>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<MyUni.Web.Models.Thesis>Thesis { get; set; }

        public DbSet<MyUni.Web.Models.Submission> Submissions { get; set; }

        public DbSet<MyUni.Web.Models.Review> Reviews { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       // public DbSet<MyUni.Web.Models.Faculty> Faculty { get; set; }
    }
}
