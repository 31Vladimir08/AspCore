namespace AspCore.Areas.Notebook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AspCore.Areas.Notebook.ViewModels;
    using AspCore.Models.Notebook;
    using AspCore.Models.Notebook.Filters;
    using AutoMapper;
    using BusinessLogic.Interfaces.Logic.Notebook;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Area("Notebook")]
    public class PersonController : Controller
    {
        private readonly INotebookLogic _iNotebookService;
        private readonly IMapper _iMapper;

        public PersonController(
            IMapper iMapper,
            INotebookLogic iNotebookService)
        {
            _iNotebookService = iNotebookService;
            _iMapper = iMapper;
        }

        // GET: NotebookController
        public IActionResult Index()
        {
            PersonViewModel personViewModel = new PersonViewModel();
            return View(personViewModel);
        }

        // POST: NotebookController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(PersonViewModel personViewModel)
        {
            personViewModel.Persons = _iMapper.Map<List<PersonUi>>(await _iNotebookService.GetPersonsAsync(_iMapper.Map<PersonsFilterDto>(personViewModel.PersonFilter)));

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
        public async Task<IActionResult> Create(PersonUi personUi)
        {
            await _iNotebookService.AddPersonAsync(_iMapper.Map<PersonDto>(personUi));
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
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _iMapper.Map<List<PersonUi>>(
                await _iNotebookService.GetPersonsAsync(_iMapper.Map<PersonsFilterDto>(new PersonsFilterUi() { Id = id }))).FirstOrDefault();
            return View(person);
        }

        // POST: NotebookController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PersonUi personUi)
        {
            await _iNotebookService.DeletePersonAsync(_iMapper.Map<PersonDto>(personUi));
            return RedirectToAction(nameof(Index));
        }
    }
}
