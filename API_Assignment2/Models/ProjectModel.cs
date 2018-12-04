using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment2.Models
{
    public class ProjectModel : DbContext
    {
        public ProjectModel(DbContextOptions<ProjectModel> options) : base(options)
        {
        }

        // reference  the Review model for CRUD
        public DbSet<Review> Reviews { get; set; }

        // reference  the Reviewer model for CRUD
        public DbSet<Reviewer> Reviewers { get; set; }
    }
}
