using CashControl.Application.UseCases.Expenses.Register;
using CashControl.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashControl.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        var useCase = new RegisterExpenseUseCase();
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }
}
