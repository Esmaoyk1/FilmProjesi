using Esel.Data;
using Esel.Interface;
using Esel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics;

namespace Esel.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly EselDbContext _context;
        readonly IRepository _repository; //kurucu içerisinde atanabilir ve de?i?tirilemez.

        public HomeController(EselDbContext context, ILogger<HomeController> logger, IRepository repository)
        {
            _context = context;
            _logger = logger;   //atan?r,bu alanlar s?n?f?n di?er yerlerinde kullan?labilir.
            _repository = repository;
        }




        //Attribute
        // [HttpGet]
        // [HttpPost]  : verileri sunucuya gondermek,kaynag? de?i?tirmek.
        // [HttpPut]
        // [HttpDelete]


        public IActionResult Index(int id)
        {
            var returnmovies = _repository.Movies;
            if (id != null && id != 0)
            {
                returnmovies = returnmovies.Where(i => i.CategoryId == id).ToList();
            }
            else
            {
                returnmovies = returnmovies.Where(i => i.CategoryId >= 0).ToList(); //filtreleme
            }
            return View(returnmovies);
        }

        [HttpPost]
        public IActionResult Index(string searchQuery)
        {
            var returnmovies = _repository.Movies;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                returnmovies = returnmovies.Where(i => i.Name.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0).ToList(); //**
            }
            else
            {
                //select * from movies where catecoryID >=0
                returnmovies = returnmovies.Where(i => i.CategoryId >= 0).ToList();
            }
            return View(returnmovies);
        }


        public IActionResult Create()   //sayfayı oluşturmaya yarayan view fonksiyondur.
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "Id", "Name");
            return View();

            // Viewbag, model, api sonucunda dönen data sayfaya data göndermenin çeşitli yollarıdır.
        }

        // boş bi kutu bunun içine herşey koyabilirsin sayı, moviemodel, yazı, liste

        public IActionResult Yenisayfa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (MovieModel m)  //sadece filmi ekleme fonksiyonudur. sayfa ile bir bağlantısı yoktur.
        {
            m.TrailerUrl = ConvertToEmbedLink(m.TrailerUrl);

            _context.Movies.Add(m);
            _context.SaveChanges();

            return View("Index", _repository.Movies);
        }


        public IActionResult Details(int id)
        {
            return View(_repository.Movies.FirstOrDefault(i => i.Id == id));
        }

        public IActionResult Delete(int id)
        {

            MovieModel silinecekFilm = _repository.Movies.FirstOrDefault(film => film.Id == id);
            if (silinecekFilm != null)
            {

                _context.Movies.Remove(silinecekFilm);
                _context.SaveChanges();
            }


            return View("Index", _repository.Movies);
        }


        private string ConvertToEmbedLink(string youtubeLink)
        {
            try
            {
                var url = new System.Uri(youtubeLink);
                var host = url.Host.ToLower();

                if (host.Contains("youtu.be"))
                {
                    //https://youtu.be/bsgcpU9P14U?si

                    // https://youtu.be/VIDEO_ID
                    return "https://www.youtube.com/embed" + url.PathAndQuery;
                }
                else if (host.Contains("youtube.com"))
                {
                    // https://www.youtube.com/watch?v=VIDEO_ID
                    var query = System.Web.HttpUtility.ParseQueryString(url.Query);
                    string videoId = query["v"];
                    if (!string.IsNullOrEmpty(videoId))
                    {
                        return "https://www.youtube.com/embed/" + videoId;
                    }
                }

                return null;
            }
            catch (System.UriFormatException)
            {
                return null; // Hatal? URL
            }
        }
    }

}
