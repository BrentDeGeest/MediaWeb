using MediaWeb.Data;
using MediaWeb.Domain.Series;
using MediaWeb.Models.Serie.Regisseur;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    public class SerieRegisseurController : Controller
    {
        private readonly DataContext _context;

        public SerieRegisseurController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<SerieRegisseurListViewModel> serieRegisseurs = new List<SerieRegisseurListViewModel>();

            IEnumerable<SerieRegisseur> regisseursFromDatabase = _context.GetSerieRegisseurs();

            foreach (SerieRegisseur regisseur in regisseursFromDatabase)
            {
                serieRegisseurs.Add(new SerieRegisseurListViewModel()
                {
                    Id = regisseur.Id,
                    Name = regisseur.Name,
                    FirstName = regisseur.FirstName

                });
            }
            return View(serieRegisseurs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SerieRegisseurCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            foreach (var regisseur in _context.SerieRegisseurs)
            {
                if (model.Name == regisseur.Name && model.FirstName == regisseur.FirstName)
                {
                    return View();
                }
            }

            var serieRegisseur = new SerieRegisseur()
            {
                Name = model.Name,
                FirstName = model.FirstName,
                BirthDate = model.BirthDate
            };

            _context.InsertSerieRegisseur(serieRegisseur);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            SerieRegisseur regisseurFromDb = _context.GetSerieRegisseur(id);


            SerieRegisseurDeleteViewModel regisseurToDelete = new SerieRegisseurDeleteViewModel()
            {
                Id = id,
                Name = regisseurFromDb.Name,
                FirstName = regisseurFromDb.FirstName
            };

            return View(regisseurToDelete);
        }

        public IActionResult ConfirmDelete(int id)
        {

            _context.DeleteSerieRegisseur(id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            SerieRegisseur regisseurFromDb = _context.GetSerieRegisseur(id);

            SerieRegisseurEditViewModel vm = new SerieRegisseurEditViewModel()
            {
                Name = regisseurFromDb.Name,
                FirstName = regisseurFromDb.FirstName,
                BirthDate = regisseurFromDb.BirthDate
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, SerieRegisseurEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            SerieRegisseur regisseurToUpdate = new SerieRegisseur()
            {
                Id = id,
                Name = model.Name,
                FirstName = model.FirstName,
                BirthDate = model.BirthDate
            };

            _context.UpdateSerieRegisseur(id, regisseurToUpdate);

            return RedirectToAction("Index");

        }
    }
}
