namespace Esel.Models
{
    public class MovieCategoryModel
    {
        public int Id { get; set; }
        public MovieModel Movie { get; set; }
        public IEnumerable<MovieModel> Movies { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
