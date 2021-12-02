using DailyExpenseTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Services.CategoryServiceInformation
{
    public class CategoryService
    {
        protected AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

    }
}
