using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyExpenseTracker.Data.Entity
{
    [Table("DailyExpense")]
    public class DailyExpense:Base
    {
        [StringLength(300)]
        public string ExpenseDetails { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateOfExpense { get; set; }
        public decimal? CostAmount { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
