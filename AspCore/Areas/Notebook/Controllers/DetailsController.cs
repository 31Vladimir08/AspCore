namespace AspCore.Areas.Notebook.Controllers
{
    using AspCore.Areas.Notebook.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Notebook")]
    public class DetailsController : Controller
    {
        public IActionResult Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DetailsViewModel detailsViewModel = new DetailsViewModel();
            return View(detailsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(DetailsViewModel details)
        {
            return View();
        }
    }
}
