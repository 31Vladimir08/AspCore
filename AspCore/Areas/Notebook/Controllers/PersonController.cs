namespace AspCore.Areas.Notebook.Controllers
{
    using AspCore.Areas.Notebook.ViewModels;
    using AspCore.Models.Notebook;
    using AutoMapper;
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.Notebook;
    using BusinessLogic.Models.Notebook.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Area("Notebook")]
    public class PersonController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly INotebookService _iNotebookService;
        private readonly IMapper _iMapper;

        public PersonController(
            IUnitOfWork iUnitOfWork,
            IMapper iMapper,
            INotebookService iNotebookService)
        {
            _iUnitOfWork = iUnitOfWork;
            _iNotebookService = iNotebookService;
            _iMapper = iMapper;
        }

        // GET: NotebookController
        public IActionResult Index(PersonViewModel personViewModel)
        {
            /*using (var unitOfWork = _iUnitOfWork.CreateTransaction())
            {
                personViewModel.Persons = _iMapper.Map<List<PersonUi>>(_iNotebookService.GetPersons(_iMapper.Map<PersonsFilterDto>(personViewModel.PersonFilter)));
            }
            */
            return View(personViewModel);
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
        public ActionResult Create(PersonUi personUi)
        {
            using (var unitOfWork = _iUnitOfWork.CreateTransaction())
            {
                _iNotebookService.AddPerson(_iMapper.Map<PersonDto>(personUi));
                unitOfWork.Commit();
            }

            return RedirectToAction(nameof(Index));
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
