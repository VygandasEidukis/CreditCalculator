using Application.Calculator;
using Application.Extensions;
using Application.Validations;

namespace Infrastructure.Calculator.ValidationHandlers;

public class DurationValidationHandler : IValidationHandler
{
    private readonly DurationValidation _durationValidation;

    public DurationValidationHandler(DurationValidation durationValidation)
    {
        _durationValidation = durationValidation;
    }

    public bool Validate(CreditCalculationInput input)
    {
        return input.Duration.InRange(_durationValidation.From, _durationValidation.To);
    }
}
