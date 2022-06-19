using Application.Calculator;
using Application.Extensions;
using Application.Validations;

namespace Infrastructure.Calculator.ValidationHandlers;
internal class TotalDebtValidationHandler : IValidationHandler
{
    private readonly TotalDebtValidation _totalDebtValidation;

    public TotalDebtValidationHandler(TotalDebtValidation totalDebtValidation)
    {
        _totalDebtValidation = totalDebtValidation;
    }

    public bool Validate(CreditCalculationInput input)
    {
        var totalDebt = input.RequestedCredit + input.PreExistingCredit;
        return totalDebt.InRange(_totalDebtValidation.From, _totalDebtValidation.To);
    }
}
