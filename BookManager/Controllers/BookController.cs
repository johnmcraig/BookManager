using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookData;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        private IBookRepo _bookRepo;

        public BookController(IBookRepo repo)
        {
            _bookRepo = repo;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View(_bookRepo.ListAll());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View(_bookRepo.GetById(id));
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book newBook, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    _bookRepo.Add(newBook);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(newBook);
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bookRepo.GetById(id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book editedBook)
        {
            if(ModelState.IsValid)
            {
                _bookRepo.Update(editedBook);
            }
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editedBook);
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_bookRepo.GetById(id));
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _bookRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_bookRepo.GetById(id));
            }
        }
    }
}