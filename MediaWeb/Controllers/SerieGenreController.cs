using MediaWeb.Data;
using MediaWeb.Domain.Series;
using MediaWeb.Models.Serie.Genre;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    public class SerieGenreController : Controller
    {
        private readonly DataContext _context;

        public SerieGenreController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<SerieGenreListViewModel> serieGenres = new List<SerieGenreListViewModel>();

            IEnumerable<SerieGenre> genresFromDatabase = _context.GetSerieGenres();

            foreach (SerieGenre genre in genresFromDatabase)
            {
                serieGenres.Add(new SerieGenreListViewModel()
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return View(serieGenres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SerieGenreCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            foreach (var genre in _context.SerieGenres)
            {
                if (model.Name == genre.Name)
                {
                    return View();
                }
            }

            var serieGenre = new SerieGenre()
            {
                Name = model.Name
            };

            _context.InsertSerieGenre(serieGenre);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            SerieGenre genreFromDb = _context.GetSerieGenre(id);


            SerieGenreDeleteViewModel genreToDelete = new SerieGenreDeleteViewModel()
            {
                Id = id,
                Name = genreFromDb.Name
            };

            return View(genreToDelete);
        }

        public IActionResult ConfirmDelete(int id)
        {

            _context.DeleteSerieGenre(id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            SerieGenre genreFromDb = _context.GetSerieGenre(id);

            SerieGenreEditViewModel vm = new SerieGenreEditViewModel()
            {
                Name = genreFromDb.Name
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, SerieGenreEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            SerieGenre genreToUpdate = new SerieGenre()
            {
                Id = id,
                Name = model.Name
            };

            _context.UpdateSerieGenre(id, genreToUpdate);

            return RedirectToAction("Index");

        }
    }
}
