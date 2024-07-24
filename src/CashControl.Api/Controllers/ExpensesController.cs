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
        return Created();
    }
}
