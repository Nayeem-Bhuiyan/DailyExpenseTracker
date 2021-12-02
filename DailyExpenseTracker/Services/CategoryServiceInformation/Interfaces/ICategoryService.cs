using DailyExpenseTracker.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Services.CategoryServiceInformation.Interfaces
{
   public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int? Id);
        Task<int> Insert(Category Category);
        Task<int> Update(Category model);
        Task<bool> DeleteById(int? Id);
    }
}
