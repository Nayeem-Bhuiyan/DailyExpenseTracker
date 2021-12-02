using DailyExpenseTracker.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Areas.DailyExpenseArea.Models
{
    public class DailyExpenseViewModel
    {
        public int DailyExpenseId { get; set; }
        public string ExpenseDetails { get; set; }
        public DateTime? DateOfExpense { get; set; }
        public decimal? CostAmount { get; set; }
        public int? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<ApplicationUser> applicationUsers{ get; set; }
        public IEnumerable<DailyExpense> dailyExpenses{ get; set; }
        public Category category{ get; set; }
        public IEnumerable<Category> categories{ get; set; }
    }
}
