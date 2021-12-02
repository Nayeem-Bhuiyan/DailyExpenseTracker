using DailyExpenseTracker.Areas.DailyExpenseArea.Models;
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
    }
}
