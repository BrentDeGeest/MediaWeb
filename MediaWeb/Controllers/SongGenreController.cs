using MediaWeb.Data;
using MediaWeb.Domain.Songs;
using MediaWeb.Models.Song.Genre;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    public class SongGenreController : Controller
    {
        private readonly DataContext _context;

        public SongGenreController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<SongGenreListViewModel> songGenres = new List<SongGenreListViewModel>();

            IEnumerable<SongGenre> genresFromDatabase = _context.GetSongGenres();

            foreach (SongGenre genre in genresFromDatabase)
            {
                songGenres.Add(new SongGenreListViewModel()
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return View(songGenres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SongGenreCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            foreach (var genre in _context.SongGenres)
            {
                if (model.Name == genre.Name)
                {
                    return View();
                }
            }

            var songGenre = new SongGenre()
            {
                Name = model.Name
            };

            _context.InsertSongGenre(songGenre);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            SongGenre genreFromDb = _context.GetSongGenre(id);


            SongGenreDeleteViewModel genreToDelete = new SongGenreDeleteViewModel()
            {
                Id = id,
                Name = genreFromDb.Name
            };

            return View(genreToDelete);
        }

        public IActionResult ConfirmDelete(int id)
        {

            _context.DeleteSongGenre(id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            SongGenre genreFromDb = _context.GetSongGenre(id);

            SongGenreEditViewModel vm = new SongGenreEditViewModel()
            {
                Name = genreFromDb.Name
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, SongGenreEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            SongGenre genreToUpdate = new SongGenre()
            {
                Id = id,
                Name = model.Name
            };

            _context.UpdateSongGenre(id, genreToUpdate);

            return RedirectToAction("Index");

        }
    }
}
