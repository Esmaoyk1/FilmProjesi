using Esel.Models;

namespace Esel.Data
{
    public class CategoryRepository
    {
        private static List<CategoryModel> _categories = null; //_movies isimli boş bir liste oluşturduk.
        static CategoryRepository()
        {
            _categories = new List<CategoryModel>()
            {
                new CategoryModel(){Id=1, Name="Animasyon"},
                new CategoryModel(){Id=2, Name="Aksiyon"},
                new CategoryModel(){Id=3, Name="Bilim-Kurgu"},
                new CategoryModel(){Id=4, Name="Biyografi"},
                new CategoryModel(){Id=5, Name="Fantastik"},
                new CategoryModel(){Id=6, Name="Gerilim"},
                new CategoryModel(){Id=7, Name="Komedi"},
                new CategoryModel(){Id=8, Name="Korku"},
                new CategoryModel(){Id=9, Name="Macera"},
                new CategoryModel(){Id=10, Name="Romantik"},
            };
        }

        public static List<CategoryModel> Categories //Tüm filmleri geriye döndürecek
        {
            get
            {
                return _categories;
            }
        }

        public static void AddCategory(CategoryModel film) //gönderilen filmi repository'e ekleyecek
        {
            _categories.Add(film);
        }


        public static CategoryModel GetById(int id) //gelen id bilgisini karşılaştırıp o id'nin bulunduğu filmi geri gönderecek
        {
            return _categories.FirstOrDefault(i => i.Id == id);
        }
    }
}
