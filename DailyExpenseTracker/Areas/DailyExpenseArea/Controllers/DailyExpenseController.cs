﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Areas.DailyExpenseArea.Controllers
{
    public class DailyExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
