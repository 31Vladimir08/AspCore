namespace AspCore.Areas.Notebook.Controllers
{
    using System;
    using System.Collections.Generic;
    using AspCore.Models.Notebook;
    using BusinessLogic;
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.Notebook;
    using BusinessLogic.Services.Notebook;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using StructureMap;

    [Area("Notebook")]
    public class PersonController : Controller
    {
        private readonly INotebookService _container;

        public PersonController(INotebookService container)
        {
            _container = container;
        }

        // GET: NotebookController
        public ActionResult Index()
        {
            var persons = new List<PersonUi>();
            var t = new UnitOfWork();
            /*var w = t.GetService<INotebookService>(_container);*/
            
            return View(persons);
        }

        // GET: NotebookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotebookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotebookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotebookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotebookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotebookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotebookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
