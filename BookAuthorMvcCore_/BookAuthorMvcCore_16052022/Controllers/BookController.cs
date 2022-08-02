using BookAuthorMvcCore_16052022.Infrastructure.Repositories.Interfaces.EntityRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAuthorMvcCore_16052022.Models.Enums;
using BookAuthorMvcCore_16052022.Models.VMs;
using BookAuthorMvcCore_16052022.Models.Entities.Concrete;

namespace BookAuthorMvcCore_16052022.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository repo;
        private readonly IDetailRepository detayRepo;
        private readonly IAuthorRepository authorRepo;

        public BookController(IBookRepository repo,IDetailRepository detayRepo,IAuthorRepository authorRepo)
        {
            this.repo = repo;
            this.detayRepo = detayRepo;
            this.authorRepo = authorRepo;
        }

 

        public IActionResult Create()
        {
            // yazarları gönderelim.
            FillAuthor();
            return View ();
        }
         
        private void FillAuthor()
        {
            ViewBag.AuthorList = authorRepo.GetDefaults(a => a.Statu != Statu.Passive);
        }

        [HttpPost]
        public IActionResult Create(CreateBookVM model)
        {
            if (ModelState.IsValid)
            {
                Detail detail = new Detail();
                detail.Summary = model.Summary;
                detail.Description = model.DetailDescription;

                Book book = new Book();
                book.Name = model.Name;
                book.Description = model.Description;
                book.PageNumber = model.PageNumber;

                book.AuthorID = model.AuthorID;
                book.BooksAuthor = authorRepo.GetDefault(a => a.ID == model.AuthorID);

                book.BooksDetail = detail;
                repo.Create(book); // kitap veritabanına gitti. sql kitaba id verdi

                detail.BookID = book.ID;
                detayRepo.Update(detail);

                return RedirectToAction("Index","Home");
            }
            FillAuthor();
            return View(model);
        }

        public IActionResult List()
        {
            return View(repo.GetDefaults(a=>a.Statu!=Statu.Passive));
        }

        public IActionResult Details(int id)
        {
            return View(repo.GetDefault(a=>a.ID==id));
        }

        public IActionResult Update(int id)
        {
            FillAuthor();
            Book book = repo.GetDefault(a => a.ID == id);
            Detail detail = detayRepo.GetDefault(a => a.ID==book.DetailID);

            UpdateBookVM updateBookVM = new UpdateBookVM();
            updateBookVM.ID = book.ID;
            updateBookVM.Name = book.Name;
            updateBookVM.Description = book.Description;
            updateBookVM.PageNumber = book.PageNumber;
            updateBookVM.AuthorID = book.AuthorID;
            updateBookVM.Summary = detail.Summary;
            updateBookVM.DetailDescription = detail.Description;

            return View(updateBookVM);

        }

        [HttpPost]
        public IActionResult Update(UpdateBookVM vm)
        {
            if (ModelState.IsValid)
            {
                Book book = repo.GetDefault(a => a.ID == vm.ID);

                book.Name = vm.Name;
                book.Description = vm.Description;
                book.PageNumber = vm.PageNumber;
                book.AuthorID = vm.AuthorID;
                book.BooksAuthor = authorRepo.GetDefault(a => a.ID == vm.AuthorID);
                book.BooksDetail.Summary = vm.Summary;
                book.BooksDetail.Description = vm.DetailDescription;
                repo.Update(book);
                return RedirectToAction("List");

            }
            FillAuthor();
            return View(vm);
        }




    }
}
