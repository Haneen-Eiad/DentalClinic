using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.ADL.DTOs.Response.Create;
using DentalClinic.ADL.Models;
using DentalClinic.ADL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Expense_Folder
{
    public class ExpenseService : IExpenseService
    {
        private readonly IGenericRepository<Expense> _expenseRepo;

        public ExpenseService(IGenericRepository<Expense> ExpenseRepo)
        {
            _expenseRepo = ExpenseRepo;
        }

        public async Task<CreateExpenseResponse> CreateExpenseAsync(CreateExpenseRequest request)
        {
            var ExpenseData = request.Adapt<Expense>();
            var expense = await _expenseRepo.CreateAsync(ExpenseData);

            if (expense is null)
            {
                return new CreateExpenseResponse { Success = false, Message = "Expense creation faild" };
            }

            return new CreateExpenseResponse { Success = true, Message = " Expense created successfully" };

        }
    }
}
