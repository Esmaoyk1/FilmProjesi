using Esel.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Esel.Data
{
    public class EselDbContext : DbContext
    {
        public EselDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<MovieCategoryModel> MovieCategoryModels { get; set; }

    }
}
