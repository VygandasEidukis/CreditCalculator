using Application.Calculator;

namespace Infrastructure.Calculator.ValidationHandlers;
public interface IValidationHandler
{
    public bool Validate(CreditCalculationInput input);
}
