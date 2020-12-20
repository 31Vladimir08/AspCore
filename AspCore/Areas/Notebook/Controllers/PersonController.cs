namespace AspCore.Areas.Notebook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspCore.Areas.Notebook.ViewModels;
    using AspCore.Models.Notebook.Entities;

    using AutoMapper;

    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    using Microsoft.AspNetCore.Mvc;

    [Area("Notebook")]
    public class PersonController : Controller
    {
        private const string _sessionKey = "personDataKey";
        private readonly INotebookService _iNotebookService;
        private readonly IMapper _iMapper;

        public PersonController(
            IMapper iMapper,
            INotebookService iNotebookService)
        {
            _iNotebookService = iNotebookService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            PersonViewModel personViewModel = new PersonViewModel();
            personViewModel.Persons = await Task.Run(
                async () =>
                {
                    return _iMapper.Map<IEnumerable<PersonUi>>(await _iNotebookService.GetPersonsAsync(_iMapper.Map<PersonsFilterDto>(personViewModel.PersonFilter)));
                });
            return View(personViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonsAction(PersonViewModel personViewModel)
        {
            personViewModel.Persons = await Task.Run(
                async () =>
                {
                    return _iMapper.Map<IEnumerable<PersonUi>>(await _iNotebookService.GetPersonsAsync(_iMapper.Map<PersonsFilterDto>(personViewModel.PersonFilter)));
                });
            return View(nameof(GetPersons), personViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonUi personUi)
        {
            await _iNotebookService.AddPersonAsync(
                await Task.Run(() => _iMapper.Map<PersonDto>(personUi)));
            return RedirectToAction(nameof(GetPersons));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var person = await Task.Run(
                async () =>
                {
                    return _iMapper.Map<IEnumerable<PersonUi>>(
                        await _iNotebookService.GetPersonsAsync(new PersonsFilterDto() { Id = id })).FirstOrDefault();
                });
            return View(person);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(PersonUi personUi)
        {
            await _iNotebookService.UpdatePersonAsync(await Task.Run(() => _iMapper.Map<PersonDto>(personUi)));
            return RedirectToAction(nameof(GetPersons));
            /*try
            {
                return RedirectToAction(nameof(GetPersons));
            }
            catch
            {
                return View();
            }*/
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var person = await Task.Run(
                async () =>
                {
                    return _iMapper.Map<IEnumerable<PersonUi>>(
                        await _iNotebookService.GetPersonsAsync(new PersonsFilterDto() { Id = id })).FirstOrDefault();
                });
            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PersonUi personUi)
        {
            await _iNotebookService.DeletePersonAsync(await Task.Run(
                () => _iMapper.Map<PersonDto>(personUi)));
            return RedirectToAction(nameof(GetPersons));
        }
    }
}
