using HiringTest.Interface;
using HiringTest.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankViewModelService _bankViewModelService;

        public BankController(IBankViewModelService bankViewModelService)
        {
            _bankViewModelService = bankViewModelService;
        }

        // GET: Bank
        public ActionResult Index()

        {
            var list = _bankViewModelService.GetAll();
            return View(list);
        }

        // GET: Bank/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _bankViewModelService.Get(id);
            return View(viewModel);
        }

        // GET: Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bank/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BankViewModel viewModel)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    var alreadyExistsId = _bankViewModelService.Get(viewModel.Id);
                    if (alreadyExistsId != null)
                    {
                        ModelState.AddModelError("Id", "Código já existente.");
                        return View(viewModel);
                    }

                    _bankViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Bank/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = _bankViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Bank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BankViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bankViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Bank/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _bankViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Bank/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bankViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _bankViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _bankViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
