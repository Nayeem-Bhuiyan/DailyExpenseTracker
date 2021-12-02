using DailyExpenseTracker.Areas.CategoryArea.Models;
using DailyExpenseTracker.Data.Entity;
using DailyExpenseTracker.Services.CategoryServiceInformation.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Areas.CategoryArea.Controllers
{
    [Area("CategoryArea")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Index()
        {
            CategoryViewModel vmModel = new CategoryViewModel()
            {
                categories = await _categoryService.GetAll()
            };
            return View(vmModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([FromForm] CategoryViewModel model)
        {

            if (model.CategoryId>0)
            {
               
                Category obj = new Category()
                {
                    Id = model.CategoryId,
                    CategoryName = model.CategoryName
                };
                await _categoryService.Update(obj);
            }
            else
            {
                Category obj = new Category()
                {

                    CategoryName = model.CategoryName
                };
                await _categoryService.Insert(obj);

            }
            return Redirect("/CategoryArea/Category/Index");

        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? Id)
        {
           return Json(await _categoryService.DeleteById(Id));
        }
    }
}
