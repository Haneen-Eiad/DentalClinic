using DentalClinic.ADL.DTOs.Request;
using DentalClinic.BLL.Service.Expense_Folder;
using DentalClinic.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DentalClinic.PL.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ExpensesController(IExpenseService expenseService, IStringLocalizer<SharedResource> localizer)
        {
            _expenseService = expenseService;
            _localizer = localizer;
        }

        [HttpPost("")]
        public async Task<IActionResult> ExpenseCreateAsync([FromBody] CreateExpenseRequest expenseRequest)
        {
            var response = await _expenseService.CreateExpenseAsync(expenseRequest);
            if (!response.Success)
            {
                return BadRequest(new {message = _localizer["ExpenseCantCreated"].Value, response});
            }
            return Ok(new { message = _localizer["ExpenseCreated"].Value, response });
        }
    }
}
