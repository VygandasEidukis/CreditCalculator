using Application.Calculator;
using Application.Extensions;
using Application.Validations;

namespace Infrastructure.Calculator.ValidationHandlers;
internal class CreditAmountValidationHandler : IValidationHandler
{
    private readonly CreditAmountValidation _creditAmountValidation;

    public CreditAmountValidationHandler(CreditAmountValidation validation)
    {
        _creditAmountValidation = validation;
    }

    public bool Validate(CreditCalculationInput input)
    {
        return input.RequestedCredit.InRange(_creditAmountValidation.From, _creditAmountValidation.To);
    }
}
