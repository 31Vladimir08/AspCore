namespace AspCore.Areas.Notebook.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AspCore.Areas.Notebook.ViewModels;
    using AspCore.Models.Notebook.Entities;
    using AutoMapper;
    using BusinessLogic.Interfaces.Services.Notebook;
    using Microsoft.AspNetCore.Mvc;

    [Area("Notebook")]
    public class DetailsController : Controller
    {
        private readonly INotebookService _iNotebookService;
        private readonly IMapper _iMapper;

        public DetailsController(
            IMapper iMapper,
            INotebookService iNotebookService)
        {
            _iNotebookService = iNotebookService;
            _iMapper = iMapper;
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DetailsViewModel detailsViewModel = new DetailsViewModel();
            var detals = await _iNotebookService.GetDetalsAsync((long)id);
            var personUi = Task.Run(
                () =>
                {
                    return _iMapper.Map<PersonUi>(detals.person.Result);
                });
            var emailsUi = Task.Run(
                () =>
                {
                    return _iMapper.Map<IEnumerable<EmailUi>>(detals.emails.Result);
                });
            var phonesUi = Task.Run(
                () =>
                {
                    return _iMapper.Map<IEnumerable<PhoneUi>>(detals.phones.Result);
                });
            var skypeUi = Task.Run(
                () =>
                {
                    return _iMapper.Map<IEnumerable<SkypeUi>>(detals.skype.Result);
                });
            await Task.WhenAll(personUi, emailsUi, phonesUi, skypeUi);
            detailsViewModel.Person = personUi.Result;
            detailsViewModel.Emails = emailsUi.Result;
            detailsViewModel.Phones = phonesUi.Result;
            detailsViewModel.Skype = skypeUi.Result;
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
        public async Task<IActionResult> Create(long? id, DetailsViewModel detailsVM)
        {
            return RedirectToAction(nameof(Details));
        }
    }
}
