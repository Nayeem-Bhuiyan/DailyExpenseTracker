using DailyExpenseTracker.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Areas.CategoryArea.Models
{
        public class CategoryViewModel
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string CommandType { get; set; }
            public Category category { get; set; }
            public IEnumerable<Category> categories { get; set; }
        }
}
