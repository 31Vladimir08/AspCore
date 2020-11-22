namespace AspCore.Areas.Notebook.Controllers
{
    using System.Collections.Generic;
    using AspCore.Models.Notebook;
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.Notebook;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Area("Notebook")]
    public class PersonController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly INotebookService _iNotebookService;

        public PersonController(
            IUnitOfWork iUnitOfWork,
            INotebookService iNotebookService)
        {
            _iUnitOfWork = iUnitOfWork;
            _iNotebookService = iNotebookService;
        }

        // GET: NotebookController
        public IActionResult Index()
        {
            var persons = new List<PersonUi>();
            /*var p = _iNotebookService.GetPersons();*/
            using (var unitOfWork = _iUnitOfWork.CreateTransaction())
            {
                var t = _iNotebookService.GetPersons();
                unitOfWork.Commit();
            }

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
