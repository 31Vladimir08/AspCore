﻿namespace AspCore.Areas.Notebook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AspCore.Areas.Notebook.ViewModels;
    using AspCore.Models.Notebook.Entities;
    using AspCore.Models.Notebook.Filters;
    using AutoMapper;
    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;
    using Microsoft.AspNetCore.Mvc;

    [Area("Notebook")]
    public class PersonController : Controller
    {
        private readonly INotebookService _iNotebookService;
        private readonly IMapper _iMapper;

        public PersonController(
            IMapper iMapper,
            INotebookService iNotebookService)
        {
            _iNotebookService = iNotebookService;
            _iMapper = iMapper;
        }

        // GET: NotebookController
        public IActionResult GetPersons()
        {
            PersonViewModel personViewModel = new PersonViewModel();
            return View(personViewModel);
        }

        // POST: NotebookController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetPersons(PersonViewModel personViewModel)
        {
            personViewModel.Persons = await Task.Run(
                async () =>
                {
                    return _iMapper.Map<IEnumerable<PersonUi>>(await _iNotebookService.GetPersonsAsync(_iMapper.Map<PersonsFilterDto>(personViewModel.PersonFilter)));
                });

            return View(personViewModel);
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
            await _iNotebookService.AddPersonAsync(
                await Task.Run(() => _iMapper.Map<PersonDto>(personUi)));
            return RedirectToAction(nameof(GetPersons));
        }

        // GET: NotebookController/Edit/5
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

        // POST: NotebookController/Edit/5
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

        // GET: NotebookController/Delete/5
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

        // POST: NotebookController/Delete/5
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
