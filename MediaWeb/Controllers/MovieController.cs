using MediaWeb.Data;
using MediaWeb.Domain.Movies;
using MediaWeb.Models;
using MediaWeb.Models.Movie;
using MediaWeb.Models.Movie.Genre;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var model = new MovieCreateViewModel();
            //IEnumerable<MovieGenre> genresFromDatabase = _context.GetMovieGenres();
            //foreach (var item in genresFromDatabase)
            //{
            //    Debug.Write(item.Name);

            //}

            var genresFromDatabase = _context.GetMovieGenres();

            foreach (var genre in genresFromDatabase)
            {
                model.Genres.Add(new CheckboxViewModel() { Id = genre.Id, Naam = genre.Name,Checked=false });
            }

            return View(model);
           // return View(model);
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
                Length = model.Length,
                Regisseurs = model.Regisseurs,
                ReleaseDate = model.ReleaseDate
            };
            foreach (var item in model.Genres.Where(x=>x.Checked==true))
            {
               
            }
            _context.InsertMovie(m);

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            Movie movieFromDb = _context.GetMovie(id);

            MovieDetailViewModel model = new MovieDetailViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                //Genre = movieFromDb.Genre,
                Length = movieFromDb.Length,
                ReleaseDate = movieFromDb.ReleaseDate
            };

            return View(model);
        }
    }
}
