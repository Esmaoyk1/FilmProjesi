using Esel.Data;
using Esel.Interface;
using Esel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Esel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly EselDbContext _context;
        readonly IRepository _repository;


        public HomeController(ILogger<HomeController> logger, EselDbContext context, IRepository repository)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
            //_repository = repository;
        }

        public IActionResult Index(int id)
        {
            var returnmovies = _repository.Movies;
            if (id != null && id!= 0)
            {
                returnmovies = returnmovies.Where(i => i.CategoryId == id).ToList();
            }
            else
            {
                returnmovies = returnmovies.Where(i=> i.CategoryId >= 0).ToList();
            }
            return View(returnmovies);

        }


        [HttpPost]
        public IActionResult Index(string searchQuery)
        {
            var returnmovies = _repository.Movies;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                returnmovies = returnmovies.Where(i => i.Name.Contains(searchQuery)).ToList();
            }
            else
            {
                //select * from movies where catecoryID >=0
                returnmovies = returnmovies.Where(i => i.CategoryId >= 0).ToList();
            }
            return View(returnmovies);
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieModel m)
        {
            _context.Movies.Add(m);
            _context.SaveChanges();

            return View("Index", _repository.Movies);


        }

        public IActionResult Details (int id)
        {
            return View(_repository.Movies.FirstOrDefault(i=>i.Id == id));
        }


    }
}
