using HiringTest.Domain.Entities;
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
    public class AccountController : Controller
    {
        private readonly IAccountViewModelService _accountViewModelService;
        private readonly IBankViewModelService _bankViewModelService;
        private readonly IPersonViewModelService _personViewModelService;
        private readonly ILogAccountViewModelService _logAccountViewModelService;

        public AccountController(IAccountViewModelService accountViewModelService, IBankViewModelService bankViewModelService, IPersonViewModelService personViewModelService
            , ILogAccountViewModelService logAccountViewModelService
            )
        {
            _accountViewModelService = accountViewModelService;
            _bankViewModelService = bankViewModelService;
            _personViewModelService = personViewModelService;
            _logAccountViewModelService = logAccountViewModelService;
        }

        // GET: Account
        public ActionResult Index()

        {
            var list = _accountViewModelService.GetAll();
            return View(list);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = _accountViewModelService.Get(id);
            return View(viewModel);
        }

        // GET: Account/Reports/5
        public ActionResult Reports(DateTime date)
        {
            var viewModel = _logAccountViewModelService.GetByDate(date);
            return View(viewModel);
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            PopulateDropDownClient();
            PopulateDropDownBank();
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var alreadyExistsId = _accountViewModelService.Get(viewModel.Id);
                    if (alreadyExistsId != null)
                    {
                        ModelState.AddModelError("Id", "Código já existente.");
                        PopulateDropDownClient();
                        PopulateDropDownBank();
                        return View(viewModel);
                    }
                    _accountViewModelService.Insert(viewModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            PopulateDropDownClient();
            PopulateDropDownBank();
            var viewModel = _accountViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccountViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _accountViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Account/Deposit/5
        public ActionResult Deposit(int id)
        {
            PopulateDropDownClient();
            PopulateDropDownBank();
            var viewModel = _accountViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Account/Deposit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(int id, AccountViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vm = _accountViewModelService.Get(id);
                    viewModel.TotalCredit += vm.TotalCredit;
                    viewModel.FinalBalance = (viewModel.PreviousBalance + viewModel.TotalCredit) - viewModel.TotalDebt;
                    _accountViewModelService.Update(viewModel);
                    LogAccountViewModel logVm = new LogAccountViewModel();
                    logVm.Account = viewModel.AccountNumber;
                    logVm.IdAccount = viewModel.Id;
                    logVm.Description = "Foi depositado um valor em " + viewModel.TotalCredit + "R$.";
                    logVm.EntryDate = DateTime.Now;
                    _logAccountViewModelService.Insert(logVm);
                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Account/Withdraw/5
        public ActionResult Withdraw(int id)
        {
            var viewModel = _accountViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Account/Withdraw/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(int id, AccountViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vm = _accountViewModelService.Get(id);
                    viewModel.TotalDebt += vm.TotalDebt;
                    viewModel.FinalBalance = (viewModel.PreviousBalance + viewModel.TotalCredit) - viewModel.TotalDebt;
                    _accountViewModelService.Update(viewModel);
                    LogAccountViewModel logVm = new LogAccountViewModel();
                    logVm.Account = viewModel.AccountNumber;
                    logVm.IdAccount = viewModel.Id;
                    logVm.Description = "Foi retirado um valor em " + viewModel.TotalCredit + "R$.";
                    logVm.EntryDate = DateTime.Now;
                    _logAccountViewModelService.Insert(logVm);
                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _accountViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _accountViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _accountViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _accountViewModelService.Get(id);
                return View(viewModel);
            }
        }

        public void PopulateDropDownClient()
        {
            ViewBag.persons = new SelectList(_personViewModelService.GetAll(), "Id", "Name");
        }

        public void PopulateDropDownBank()
        {
            ViewBag.banks = new SelectList(_bankViewModelService.GetAll(), "Id", "Name");
        }


    }
}
