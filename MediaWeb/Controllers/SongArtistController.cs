using MediaWeb.Data;
using MediaWeb.Domain.Songs;
using MediaWeb.Models.Song.Artist;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    public class ArtistController : Controller
    {
        private readonly DataContext _context;

        public ArtistController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ArtistListViewModel> artists = new List<ArtistListViewModel>();

            IEnumerable<Artist> regisseursFromDatabase = _context.GetSongArtists();

            foreach (Artist regisseur in regisseursFromDatabase)
            {
                artists.Add(new ArtistListViewModel()
                {
                    Id = regisseur.Id,
                    Name = regisseur.Name,
                    FirstName = regisseur.FirstName

                });
            }
            return View(artists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArtistCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            foreach (var regisseur in _context.Artists)
            {
                if (model.Name == regisseur.Name && model.FirstName == regisseur.FirstName)
                {
                    return View();
                }
            }

            var artist = new Artist()
            {
                Name = model.Name,
                FirstName = model.FirstName
            };

            _context.InsertSongArtist(artist);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Artist regisseurFromDb = _context.GetSongArtist(id);


            ArtistDeleteViewModel regisseurToDelete = new ArtistDeleteViewModel()
            {
                Id = id,
                Name = regisseurFromDb.Name,
                FirstName = regisseurFromDb.FirstName
            };

            return View(regisseurToDelete);
        }

        public IActionResult ConfirmDelete(int id)
        {

            _context.DeleteSongArtist(id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Artist regisseurFromDb = _context.GetSongArtist(id);

            ArtistEditViewModel vm = new ArtistEditViewModel()
            {
                Name = regisseurFromDb.Name,
                FirstName = regisseurFromDb.FirstName
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, ArtistEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            Artist regisseurToUpdate = new Artist()
            {
                Id = id,
                Name = model.Name,
                FirstName = model.FirstName
            };

            _context.UpdateSongArtist(id, regisseurToUpdate);

            return RedirectToAction("Index");

        }
    }
}
