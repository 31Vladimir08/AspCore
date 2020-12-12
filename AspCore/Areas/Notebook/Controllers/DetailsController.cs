namespace AspCore.Areas.Notebook.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AspCore.Areas.Notebook.ViewModels;
    using AspCore.Models.Notebook.Entities;
    using AutoMapper;
    using BusinessLogic.Interfaces.Logic.Notebook;
    using Microsoft.AspNetCore.Mvc;

    [Area("Notebook")]
    public class DetailsController : Controller
    {
        private readonly INotebookLogic _iNotebookLogic;
        private readonly IMapper _iMapper;

        public DetailsController(
            IMapper iMapper,
            INotebookLogic iNotebookLogic)
        {
            _iNotebookLogic = iNotebookLogic;
            _iMapper = iMapper;
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DetailsViewModel detailsViewModel = new DetailsViewModel();
            var detals = await _iNotebookLogic.GetDetalsAsync((long)id);

            detailsViewModel.Person = _iMapper.Map<PersonUi>(detals.Person);
            detailsViewModel.Emails = _iMapper.Map<IEnumerable<EmailUi>>(detals.Emails);
            detailsViewModel.Phones = _iMapper.Map<IEnumerable<PhoneUi>>(detals.Phones);
            detailsViewModel.Skype = _iMapper.Map<IEnumerable<SkypeUi>>(detals.Skype);
            return View(detailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(DetailsViewModel details)
        {
            return View();
        }

        // GET: NotebookController/Create
        public ActionResult Create(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DetailsViewModel detailsViewModel = new DetailsViewModel();
            detailsViewModel.Person.Id = (long)id;
            return View(detailsViewModel);
        }

        // POST: NotebookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonUi personUi)
        {
            //await _iNotebookLogic.AddPersonAsync(_iMapper.Map<PersonDto>(personUi));
            return RedirectToAction(nameof(Details));
        }
    }
}
