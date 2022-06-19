using Application.Calculator;
using Application.Extensions;
using Application.Validations;

namespace Infrastructure.Calculator.ValidationHandlers;
public class TotalDebtValidationHandler : IValidationHandler
{
    private readonly TotalDebtValidation _totalDebtValidation;

    public TotalDebtValidationHandler(TotalDebtValidation totalDebtValidation)
    {
        _totalDebtValidation = totalDebtValidation;
    }

    public bool Validate(CreditCalculationInput input)
    {
        if (input.RequestedCredit < 0 || input.PreExistingCredit < 0)
        {
            return false;
        }

        var totalDebt = input.RequestedCredit + input.PreExistingCredit;
        return totalDebt.InRange(_totalDebtValidation.From, _totalDebtValidation.To);
    }
}
