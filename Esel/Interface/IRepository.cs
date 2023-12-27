using Esel.Models;

namespace Esel.Interface
{
    public interface IRepository
    {
        IEnumerable<MovieModel> Movies { get; }
        IEnumerable<CategoryModel> Categories { get; }
    }
}
