using HiringTest.Interface;
using HiringTest.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonViewModelService _personViewModelService;
        
        public PersonController(IPersonViewModelService personViewModelService)
        {
            _personViewModelService = personViewModelService;
        }
        
        // GET: Person
        public ActionResult Index()
        {
            if(_personViewModelService.GetAll() != null)
            {
                var list = _personViewModelService.GetAll();
                return View(list);
            }
            return View();
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _personViewModelService.Get(id);
            return View(viewModel);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var alreadyExistsId = _personViewModelService.Get(viewModel.Id);
                    if (alreadyExistsId != null)
                    {
                        ModelState.AddModelError("Id", "Código já existente.");
                        return View(viewModel);
                    }
                    _personViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
                
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = _personViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PersonViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personViewModelService.Update(viewModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _personViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Person/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personViewModelService.Delete(id);
                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _personViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _personViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
