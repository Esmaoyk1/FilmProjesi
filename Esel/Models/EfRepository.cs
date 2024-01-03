using Esel.Data;
using Esel.Interface;

namespace Esel.Models
{
    public class EfRepository : IRepository
    {
        readonly EselDbContext _context;

        public EfRepository(EselDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieModel> Movies => _context.Movies; //filmleri döndürdük *return.

   
        public IEnumerable<CategoryModel> Categories => _context.Category;

    }
}
