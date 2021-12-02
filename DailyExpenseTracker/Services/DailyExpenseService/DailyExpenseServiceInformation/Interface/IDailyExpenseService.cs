using DailyExpenseTracker.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Services.DailyExpenseService.DailyExpenseServiceInformation.Interface
{
   public interface IDailyExpenseService
    {
        Task<IEnumerable<DailyExpense>> GetAll();
        Task<DailyExpense> GetById(int? id);
        Task<int> Save(DailyExpense model);
        Task<bool> Delete(int? id);

    }
}
