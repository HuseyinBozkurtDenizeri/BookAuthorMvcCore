using BookAuthorMvcCore_16052022.Infrastructure.Repositories.Interfaces.EntityRepo;
using BookAuthorMvcCore_16052022.Models.DTOs;
using BookAuthorMvcCore_16052022.Models.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthorMvcCore_16052022.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository repo;

        public AuthorController(IAuthorRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorDTO dto)
        {
            if (ModelState.IsValid)
            {
                Author author = new Author();
                author.Biography = dto.Biography;
                author.LastName = dto.LastName;
                author.FirstName = dto.FirstName;
                repo.Create(author);
                return RedirectToAction("List");
            }
            else return View(dto);
        }

        public IActionResult List()
        {
         return View(repo.GetDefaults(a => a.Statu != Models.Enums.Statu.Passive));
        }

        public IActionResult Detail(int id)
        {
            return View(repo.GetDefault(a=>a.ID==id));
        }

        public IActionResult Delete(int id)
        {
            Author author = repo.GetDefault(a => a.ID == id);
            return View(author);
        }


        [HttpPost]
        public IActionResult Delete(Author author)
        {
            Author deleted = repo.GetDefault(a => a.ID == author.ID);
            repo.Delete(deleted);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            Author author = repo.GetDefault(a => a.ID == id);

            UpdateAuthorDTO dto = new UpdateAuthorDTO();
            dto.ID = author.ID;
            dto.LastName = author.LastName;
            dto.FirstName = author.FirstName;
            dto.Biography = author.Biography;
            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(UpdateAuthorDTO model)
        {
            Author author = repo.GetDefault(a => a.ID == model.ID);

            author.FirstName = model.FirstName;
            author.LastName = model.LastName;
            author.Biography = model.Biography;
            repo.Update(author);
            return RedirectToAction("List");
        }

       
    }
}
