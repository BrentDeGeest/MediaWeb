using MediaWeb.Data;
using MediaWeb.Domain.Movies;
using MediaWeb.Models.Movie.Regisseur;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    public class MovieRegisseurController : Controller
    {
        private readonly DataContext _context;

        public MovieRegisseurController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<MovieRegisseurListViewModel> movieRegisseurs = new List<MovieRegisseurListViewModel>();

            IEnumerable<MovieRegisseur> regisseursFromDatabase = _context.GetMovieRegisseurs();

            foreach (MovieRegisseur regisseur in regisseursFromDatabase)
            {
                movieRegisseurs.Add(new MovieRegisseurListViewModel()
                {
                    Id = regisseur.Id,
                    Name = regisseur.Name,
                    FirstName = regisseur.FirstName
                    
                });
            }
            return View(movieRegisseurs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieRegisseurCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            foreach (var regisseur in _context.MovieRegisseurs)
            {
                if (model.Name == regisseur.Name && model.FirstName == regisseur.FirstName)
                {
                    return View();
                }
            }

            var movieRegisseur = new MovieRegisseur()
            {
                Name = model.Name,
                FirstName = model.FirstName,
                BirthDate = model.BirthDate
            };

            _context.InsertMovieRegisseur(movieRegisseur);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            MovieRegisseur regisseurFromDb = _context.GetMovieRegisseur(id);


            MovieRegisseurDeleteViewModel regisseurToDelete = new MovieRegisseurDeleteViewModel()
            {
                Id = id,
                Name = regisseurFromDb.Name,
                FirstName = regisseurFromDb.FirstName
            };

            return View(regisseurToDelete);
        }

        public IActionResult ConfirmDelete(int id)
        {

            _context.DeleteMovieRegisseur(id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            MovieRegisseur regisseurFromDb = _context.GetMovieRegisseur(id);

            MovieRegisseurEditViewModel vm = new MovieRegisseurEditViewModel()
            {
                Name = regisseurFromDb.Name,
                FirstName = regisseurFromDb.FirstName,
                BirthDate = regisseurFromDb.BirthDate
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRegisseurEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            MovieRegisseur regisseurToUpdate = new MovieRegisseur()
            {
                Id = id,
                Name = model.Name,
                FirstName = model.FirstName,
                BirthDate = model.BirthDate
            };

            _context.UpdateMovieRegisseur(id, regisseurToUpdate);

            return RedirectToAction("Index");

        }
    }
}
