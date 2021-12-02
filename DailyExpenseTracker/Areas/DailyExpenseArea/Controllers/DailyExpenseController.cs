using DailyExpenseTracker.Areas.DailyExpenseArea.Models;
using DailyExpenseTracker.Data.Entity;
using DailyExpenseTracker.Services.CategoryServiceInformation;
using DailyExpenseTracker.Services.DailyExpenseService.DailyExpenseServiceInformation;
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
        public readonly DailyExpenseService _dailyExpenseService;
        public readonly CategoryService _categoryService;
        public DailyExpenseController(DailyExpenseService dailyExpenseService, CategoryService categoryService)
        {
            _dailyExpenseService = dailyExpenseService;
            _categoryService = categoryService;
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
            DailyExpense obj = new DailyExpense()
            {
                Id = model.DailyExpenseId,
                ApplicationUserId = model.ApplicationUserId,
                CategoryId = model.CategoryId,
                CostAmount = model.CostAmount,
                DateOfExpense = model.DateOfExpense,
            };
            await _dailyExpenseService.Save(obj);
            return Redirect("/CategoryArea/Category/Index");

        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? Id)
        {
            return Json(await -_dailyExpenseService.Delete(Id));
        }
    }
}
