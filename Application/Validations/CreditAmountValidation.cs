using System.Diagnostics.CodeAnalysis;

namespace Application.Validations;

[ExcludeFromCodeCoverage]
public class CreditAmountValidation : IValidation
{
    public int? From { get; set; }
    public int? To { get; set; }
}
