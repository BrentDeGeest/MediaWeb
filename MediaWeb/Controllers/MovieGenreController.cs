using MediaWeb.Data;
using MediaWeb.Domain.Movies;
using MediaWeb.Models.Movie.Genre;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    public class MovieGenreController : Controller
    {

        private readonly DataContext _context;

        public MovieGenreController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<MovieGenreListViewModel> movieGenres = new List<MovieGenreListViewModel>();

            IEnumerable<MovieGenre> genresFromDatabase = _context.GetMovieGenres();

            foreach (MovieGenre genre in genresFromDatabase)
            {
                movieGenres.Add(new MovieGenreListViewModel()
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return View(movieGenres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieGenreCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            foreach (var genre in _context.MovieGenres)
            {
                if(model.Name == genre.Name)
                {
                    return View();
                }
            }

            var movieGenre = new MovieGenre()
            {
                Name = model.Name
            };
            
            _context.InsertMovieGenre(movieGenre);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            MovieGenre genreFromDb = _context.GetMovieGenre(id);


            MovieGenreDeleteViewModel genreToDelete = new MovieGenreDeleteViewModel()
            {
                Id = id,
                Name = genreFromDb.Name
            };

            return View(genreToDelete);
        }

        public IActionResult ConfirmDelete(int id)
        {

            _context.DeleteMovieGenre(id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            MovieGenre genreFromDb = _context.GetMovieGenre(id);

            MovieGenreEditViewModel vm = new MovieGenreEditViewModel()
            {
                Name = genreFromDb.Name
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieGenreEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            MovieGenre genreToUpdate = new MovieGenre()
            {
                Id = id,
                Name = model.Name
            };

            _context.UpdateMovieGenre(id, genreToUpdate);

            return RedirectToAction("Index");

        }

    }
}
