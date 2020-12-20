namespace AspCore.Areas.Notebook.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AspCore.Areas.Notebook.ViewModels;
    using AspCore.Models.Notebook.Entities;
    using AspCore.Session;

    using AutoMapper;

    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Models.Notebook.Entities;

    using Microsoft.AspNetCore.Mvc;

    [Area("Notebook")]
    public class DetailsController : Controller
    {
        private const string _sessionKey = "detailsDataKey";
        private readonly INotebookService _iNotebookService;
        private readonly IMapper _iMapper;

        public DetailsController(
            IMapper iMapper,
            INotebookService iNotebookService)
        {
            _iNotebookService = iNotebookService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var detailsViewModel = await Task.Run(() => HttpContext.Session.GetObject<DetailsViewModel>(_sessionKey));
            if (detailsViewModel == null || detailsViewModel.Person.Id != id)
            {
                detailsViewModel = new DetailsViewModel();
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
                await Task.Run(
                () =>
                {
                    HttpContext.Session.SetObject(_sessionKey, detailsViewModel);
                });
            }

            return View(detailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DetailsViewModel detailsViewModel = new DetailsViewModel();
            detailsViewModel.Person.Id = (long)id;
            return View(detailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(long? id, DetailsViewModel detailsVM)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            detailsVM.Email.PersonId = (long)id;
            detailsVM.Phone.PersonId = (long)id;
            detailsVM.SkypePerson.PersonId = (long)id;
            var emailDto = Task.Run(
                () =>
                {
                    return _iMapper.Map<EmailDto>(detailsVM.Email);
                });
            var phoneDto = Task.Run(
                () =>
                {
                    return _iMapper.Map<PhoneDto>(detailsVM.Phone);
                });
            var skypeDto = Task.Run(
                () =>
                {
                    return _iMapper.Map<SkypeDto>(detailsVM.SkypePerson);
                });
            await Task.WhenAll(emailDto, phoneDto, skypeDto);
            await _iNotebookService.AddDetalsForPersonAsync(emailDto.Result, phoneDto.Result, skypeDto.Result);
            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
