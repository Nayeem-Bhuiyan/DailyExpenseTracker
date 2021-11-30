using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Data.Entity
{
    [Table("Category")]
    public class Category:Base
    {
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
    }
}
