using Application.Calculator;
using CreditCalcuatorApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalcuatorApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CreditController : ControllerBase
{
    private readonly ICalculator<CreditCalculationInput, CreditResult> _calculator;

    public CreditController(ICalculator<CreditCalculationInput, CreditResult> calculator)
    {
        _calculator = calculator;
    }

    [HttpGet]
    public ActionResult<CreditResponse> Get([FromQuery] int duration, [FromQuery] int preExistingCredit, [FromQuery] int requestedCredit)
    {
        CreditCalculationInput input = new CreditCalculationInput
        {
            Duration = duration,
            PreExistingCredit = preExistingCredit,
            RequestedCredit = requestedCredit,
        };

        var result = _calculator.Calculate(input);

        if (result.Successful)
        {
            return Ok(new CreditResponse
            {
                Percentage = result.Reward,
                Success = result.Successful,
            });
        }
        else
        {
            return BadRequest(new CreditResponse());
        }
    }
}
