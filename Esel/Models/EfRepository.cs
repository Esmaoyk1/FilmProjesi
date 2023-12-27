using Esel.Data;
using Esel.Interface;

namespace Esel.Models
{
    public class EfRepository : IRepository
    {
        private EselDbContext _context;

        public EfRepository(EselDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieModel> Movies => _context.Movies;

        public IEnumerable<CategoryModel> Categories => _context.Category;
    }
}
