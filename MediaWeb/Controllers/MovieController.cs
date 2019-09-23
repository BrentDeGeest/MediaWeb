using MediaWeb.Data;
using MediaWeb.Domain.Movies;
using MediaWeb.Models.Movie;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly DataContext _context;

        public MovieController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<MovieListViewModel> movies = new List<MovieListViewModel>();

            IEnumerable<Movie> moviesFromDatabase = _context.GetMovies();

            foreach (Movie movie in moviesFromDatabase)
            {
                movies.Add(new MovieListViewModel()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Cover = movie.Cover
                });
            }
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            foreach (var movie in _context.Movies)
            {
                if (model.Title == movie.Title)
                {
                    return View();
                }
            }

            var m = new Movie()
            {
                Title = model.Title,
                Cover = model.Cover,
                Description = model.Description,
                Genres = model.Genres,
                Length = model.Length,
                Regisseurs = model.Regisseurs,
                ReleaseDate = model.ReleaseDate
            };

            _context.InsertMovie(m);

            return RedirectToAction("Index");
        }
    }
}
