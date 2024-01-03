using Esel.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Esel.Data
{
    public class EselDbContext : DbContext          //entity paketi
    {
        public EselDbContext(DbContextOptions options) : base(options) //** veritabanı bağlamı sınıfının yapıcı metodunu temsil eder //base:yapıcı metodu cagırdık
        {
        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<CategoryModel> Category { get; set; }

       
    }
}
