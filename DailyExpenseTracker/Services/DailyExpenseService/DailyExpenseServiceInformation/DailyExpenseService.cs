using DailyExpenseTracker.Data;
using DailyExpenseTracker.Data.Entity;
using DailyExpenseTracker.Services.DailyExpenseService.DailyExpenseServiceInformation.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyExpenseTracker.Services.DailyExpenseService.DailyExpenseServiceInformation
{
    public class DailyExpenseService : IDailyExpenseService
    {
        public readonly AppDbContext _context;

        public DailyExpenseService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<DailyExpense>> GetAll()
        {
          return  await _context.DailyExpenses.Include(x=>x.ApplicationUser).Include(x => x.Category).AsNoTracking().ToListAsync();
        }

        public async Task<DailyExpense> GetById(int? id)
        {
            return await _context.DailyExpenses.Where(x=>x.Id==id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<int> Save(DailyExpense model)
        {
            if (model.Id>0)
            {
                _context.DailyExpenses.Update(model);
              return await _context.SaveChangesAsync();
            }
            else
            {
                _context.DailyExpenses.Add(model);
              return  await _context.SaveChangesAsync();
            }
            
        }

        public async Task<bool> Delete(int? id)
        {
             _context.DailyExpenses.Remove(await GetById(id));
             await _context.SaveChangesAsync();
             return true;

        }
    }
}
