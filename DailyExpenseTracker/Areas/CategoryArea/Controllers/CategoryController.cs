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

            if (model.CommandType=="Insert")
            {
                Category obj = new Category()
                {
                    CategoryName = model.CategoryName
                };
                 await _categoryService.Insert(obj);
                return RedirectToAction(nameof(Index));
            }
            else if(model.CommandType == "Update")
            {
                Category obj = new Category()
                {
                    Id=model.CategoryId,
                    CategoryName = model.CategoryName
                };
                await _categoryService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            else if (model.CommandType == "Delete")
            {
                await _categoryService.DeleteById(model.CategoryId);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }

            
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Value>> Get(int id)
        //{
        //    var response = await _repository.GetById(id);
        //    if (response == null) { return NotFound(); }
        //    return response;
        //}

        //// POST api/values
        //[HttpPost]
        //public async Task Post([FromBody] Value value)
        //{
        //    await _repository.Insert(value);
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public async Task Delete(int id)
        //{
        //    await _repository.DeleteById(id);
        //}
    }
}
