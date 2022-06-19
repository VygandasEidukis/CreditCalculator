using Application.Exceptions;
using Application.Validations;
using Infrastructure.Calculator.ValidationHandlers;

namespace Infrastructure.Adapters;
internal static class ValidationAdapter
{
    public static IValidationHandler GetValidationHandler(IValidation validation)
    {
        switch (validation)
        {
            case CreditAmountValidation:
                return new CreditAmountValidationHandler(validation as CreditAmountValidation);
            case TotalDebtValidation:
                return new TotalDebtValidationHandler(validation as TotalDebtValidation);
            case DurationValidation:
                return new DurationValidationHandler(validation as DurationValidation);
            default:
                throw new ValidationHandlerNotImplemented();
        }
    }
}
