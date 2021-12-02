using DailyExpenseTracker.Areas.DailyExpenseArea.Models;
using DailyExpenseTracker.Data.Entity;
using DailyExpenseTracker.Services.CategoryServiceInformation;
using DailyExpenseTracker.Services.CategoryServiceInformation.Interfaces;
using DailyExpenseTracker.Services.DailyExpenseService.DailyExpenseServiceInformation;
using DailyExpenseTracker.Services.DailyExpenseService.DailyExpenseServiceInformation.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Areas.DailyExpenseArea.Controllers
{
    [Area("DailyExpenseArea")]
    public class DailyExpenseController : Controller
    {
        public readonly IDailyExpenseService _dailyExpenseService;
        private readonly UserManager<ApplicationUser> _userManager;
        public readonly ICategoryService _categoryService;
        public DailyExpenseController(IDailyExpenseService dailyExpenseService, ICategoryService categoryService, UserManager<ApplicationUser> userManager)
        {
            _dailyExpenseService = dailyExpenseService;
            _categoryService = categoryService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            DailyExpenseViewModel data = new DailyExpenseViewModel
            {
             categories=await _categoryService.GetAll(),
             dailyExpenses=await _dailyExpenseService.GetAll(),

            };
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([FromForm] DailyExpenseViewModel model)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            DailyExpense obj = new DailyExpense()
            {
                Id = model.DailyExpenseId,
                ApplicationUserId = user?.Id,
                CategoryId = model.CategoryId,
                CostAmount = model.CostAmount,
                DateOfExpense = model.DateOfExpense,
                ExpenseDetails=model.ExpenseDetails
            };
            await _dailyExpenseService.Save(obj);
            return Redirect("/CategoryArea/Category/Index");

        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? Id)
        {
            return Json(await _dailyExpenseService.Delete(Id));
        }
    }
}
