using MediaWeb.Data;
using MediaWeb.Domain.Podcasts;
using MediaWeb.Models.Podcast.Author;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    public class PodcastAuthorController : Controller
    {
        private readonly DataContext _context;

        public PodcastAuthorController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<AuthorListViewModel> authors = new List<AuthorListViewModel>();

            IEnumerable<Author> authorsFromDatabase = _context.GetPodcastAuthors();

            foreach (Author author in authorsFromDatabase)
            {
                authors.Add(new AuthorListViewModel()
                {
                    Id = author.Id,
                    Name = author.Name,
                    FirstName = author.FirstName

                });
            }
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuthorCreateViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            foreach (var author in _context.Authors)
            {
                if (model.Name.ToLower() == author.Name.ToLower() && model.FirstName.ToLower() == author.FirstName.ToLower())
                {
                    return View();
                }
            }

            var newAuthor = new Author()
            {
                Name = model.Name,
                FirstName = model.FirstName
                
            };

            _context.InsertPodcastAuthor(newAuthor);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Author authorFromDb = _context.GetPodcastAuthor(id);


            AuthorDeleteViewModel authorToDelete = new AuthorDeleteViewModel()
            {
                Id = id,
                LastName = authorFromDb.Name,
                FirstName = authorFromDb.FirstName
            };

            return View(authorToDelete);
        }

        public IActionResult ConfirmDelete(int id)
        {

            _context.DeletePodcastAuthor(id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Author authorFromDb = _context.GetPodcastAuthor(id);

            AuthorEditViewModel vm = new AuthorEditViewModel()
            {
                Name = authorFromDb.Name,
                FirstName = authorFromDb.FirstName,
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, AuthorEditViewModel model)
        {
            if (!TryValidateModel(model))
            {
                return View(model);
            }

            Author authorToUpdate = new Author()
            {
                Id = id,
                Name = model.Name,
                FirstName = model.FirstName,
            };

            _context.UpdatePodcastAuthor(id, authorToUpdate);

            return RedirectToAction("Index");

        }
    }
}
